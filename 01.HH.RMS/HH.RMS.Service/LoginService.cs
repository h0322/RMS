using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;
using HH.RMS.Model;
using HH.RMS.Repository.ADONet.Interface;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HH.RMS.Service
{
    public class LoginService : ServiceBase,ILoginService
    {
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<AccountRoleEntity> _accountRoleRepository;
        private IRepository<PersonEntity> _personRepository;
        public LoginService(IRepository<AccountEntity> accountRepository, IRepository<RoleEntity> roleRepository, IRepository<AccountRoleEntity> accountRoleRepository, IRepository<PersonEntity> personRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _accountRoleRepository = accountRoleRepository;
            _personRepository = personRepository;
        }
        public ResultModel<AccountDetailModel> UserLogin(string accountName, string password)
        {
            ResultModel<AccountDetailModel> result = new ResultModel<AccountDetailModel>();
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _accountRepository.Query(db)
                             join b in _accountRoleRepository.Query(db)
                             on a.id equals b.accountId
                             join c in _roleRepository.Query(db)
                             on b.roleId equals c.id
                             join d in _personRepository.Query(db)
                             on a.personId equals d.id
                             where a.accountName == accountName && a.password == password && (c.roleType == RoleType.Admin || c.roleType == RoleType.SuperUser)
                             select new AccountDetailModel
                             {
                                 account = new AccountModel() { accountName = a.accountName, accountId = a.id, level = a.level, score = a.score,amount = a.amount },
                                 person = new PersonModel() { name = d.name, birthday = d.birthday, cityId = d.cityId, provinceId = d.provinceId, sex = d.sex, countryId = d.countryId, personId = d.id, nickName = d.nickName },
                                 role = new RoleModel() { roleName = c.roleName, roleId = c.id, roleOrder = c.roleOrder, roleType = c.roleType },
                             });
                    result.resultObj = q.FirstOrDefault();
                }
                if (result.resultObj != null)
                {
                    result.resultType = ResultType.Success;
                    result.resultMsg = "Login Success";
                }
                else
                {
                    result.resultType = ResultType.Fail;
                    result.resultMsg = "Login Fail";
                }
            }
            catch (Exception ex)
            {
                log.Error("LoginService.ResultModel", ex);
                result.resultType = ResultType.SystemError;
                result.resultMsg = "Login Fail";
            }
            return result;
        }
        public void ExitLogin()
        {

            SessionHelper.SessionClear();
            HttpContext.Current.Response.Redirect("/Login/Index", true);
        }
    }
}
