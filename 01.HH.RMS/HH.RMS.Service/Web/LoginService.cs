using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository.ADONet.Interface;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HH.RMS.Service.Model;
using System.Web.Security;
using Nelibur.ObjectMapper;

namespace HH.RMS.Service.Web
{
    public class LoginService : ServiceBase,ILoginService
    {
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<AccountRoleEntity> _accountRoleRepository;
        private IRepository<PersonEntity> _personRepository;
        private IRepository<LevelEntity> _levelRepository;
        public LoginService(IRepository<LevelEntity> levelRepository,IRepository<AccountEntity> accountRepository, IRepository<RoleEntity> roleRepository, IRepository<AccountRoleEntity> accountRoleRepository, IRepository<PersonEntity> personRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _accountRoleRepository = accountRoleRepository;
            _personRepository = personRepository;
            _levelRepository = levelRepository;
        }
        public ResultModel<AccountModel> UserLogin(string accountName, string password)
        {
            ResultModel<AccountModel> result = new ResultModel<AccountModel>();
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
                             join e in _levelRepository.Query(db) on a.levelId equals e.id
                             where a.accountName == accountName && a.password == password && (c.roleType == RoleType.Admin || c.roleType == RoleType.SuperUser)
                             select new AccountModel
                             {
                                 accountName = a.accountName,
                                 id = a.id,
                                 score = a.score,
                                 amount = a.amount,
                                 person = new PersonModel() { name = d.name, birthday = d.birthday, id = d.id, provinceId = d.provinceId, sex = d.sex, countryId = d.countryId, cityId = d.cityId, nickName = d.nickName },
                                 role = new RoleModel() { roleName = c.roleName, id = c.id, roleOrder = c.roleOrder, roleType = c.roleType },
                                 level = new LevelModel() { levelName = e.levelName, id = e.id, remark = e.remark }
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
            FormsAuthentication.SignOut();
            return;
        }
    }
}
