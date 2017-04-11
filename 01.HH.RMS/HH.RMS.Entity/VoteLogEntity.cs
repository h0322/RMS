using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
     [MappingTable(tableName = "VoteLog")]
    public class VoteLogEntity : EntityBase
    {
         public long voteId { get; set; }
         public long voteBoxId { get; set; }
         public long accountId { get; set; }
    }
}
