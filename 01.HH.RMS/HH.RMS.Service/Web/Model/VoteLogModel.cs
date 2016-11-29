using HH.RMS.Common.Attributes;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    public class VoteLogModel : EntityBase
    {
         public long voteId { get; set; }
         public long accountId { get; set; }
         public static T ModelMapper<T>(object entity)
         {
             return TinyMapper.Map<T>(entity);
         }
         public static T EntityMapper<T>(object model)
         {
             return TinyMapper.Map<T>(model);
         }
    }
}
