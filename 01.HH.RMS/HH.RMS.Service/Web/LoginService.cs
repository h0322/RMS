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
    public class LoginService : ILoginService
    {
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<PersonEntity> _personRepository;
        private IRepository<LevelEntity> _levelRepository;
        public LoginService(IRepository<LevelEntity> levelRepository,IRepository<AccountEntity> accountRepository, IRepository<RoleEntity> roleRepository, IRepository<PersonEntity> personRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
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
                             join b in _personRepository.Query(db) on a.personId equals b.id
                             join c in _levelRepository.Query(db) on a.levelId equals c.id
                             where a.accountName == accountName && a.password == password && (a.accountType == AccountType.Admin || a.accountType == AccountType.SuperUser)
                             select new AccountModel
                             {
                                 accountName = a.accountName,
                                 id = a.id,
                                 score = a.score,
                                 amount = a.amount,
                                 roleBitMap = a.roleBitMap,
                                 status = a.status,
                                 remark = a.remark,
                                 accountType = a.accountType,
                                 name = b.name, 
                                 birthday = b.birthday, 
                                 personId = b.id, 
                                 provinceId = b.provinceId, 
                                 sex = b.sex, 
                                 countryId = b.countryId, 
                                 cityId = b.cityId, 
                                 nickName = b.nickName,
                                 levelName = c.levelName,
                                 levelId = c.id,
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
                Config.log.Error("LoginService.ResultModel", ex);
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
