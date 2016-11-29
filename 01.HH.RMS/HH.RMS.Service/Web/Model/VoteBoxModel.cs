using HH.RMS.Common.Attributes;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    public class VoteBoxModel : EntityBase
    {
        public long voteId { get; set; }
        [MaxLength(100)]
        public string voteTitle { get; set; }
        public int voteCount { get; set; }
        public decimal rate { get; set; }
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
