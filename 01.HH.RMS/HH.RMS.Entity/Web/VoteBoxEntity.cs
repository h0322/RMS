using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "VoteBox")]
    public class VoteBoxEntity : EntityBase
    {
        public long voteId { get; set; }
        [MaxLength(100)]
        public string voteTitle { get; set; }
        public int voteCount { get; set; }
        public decimal rate { get; set; }
    }
}
