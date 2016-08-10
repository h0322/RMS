using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service
{
    public class PersonService:ServiceBase,IPersonService
    {
        private IRepository<PersonEntity> _personRepository;
        private IRepository<AccountEntity> _accountRepository;
        public PersonService(IRepository<PersonEntity> personRepository, IRepository<AccountEntity> accountRepository)
        {
            _personRepository = personRepository;
            _accountRepository = accountRepository;
        }
        public ResultModel<PersonListModel> QueryPersonList(PagerModel pager)
        {
            try{
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _personRepository.Query(db)
                             join b in _accountRepository.Query(db) on a.id equals b.personId
                             select new PersonModel
                             {
                                personId = a.id,
                                birthday = a.birthday,
                                city = a.city,
                                country = a.country,
                                name = a.name,
                                nickName = a.nickName,
                                privonce = a.privonce,
                                remark = a.remark,
                                sex = a.sex
                             });

                    if (pager != null)
                    {
                        q = q.OrderByDescending(m => m.personId).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
                    }
                    PersonListModel list = new PersonListModel() { personList = q.ToList() };
                    return new ResultModel<PersonListModel>(ResultType.Success, list);
                    //return null;
                }
            }
            catch (Exception ex)
            {
                log.Error("PersonService.QueryPersonList", ex);
                return new ResultModel<PersonListModel>(ResultType.SystemError, null);
            }
        }
        public PersonEntity QueryPersonById(long id)
        {

            //return _personRepository.Query().Where(m=>m.id==id).FirstOrDefault();
            return null;
        }
    }
}
