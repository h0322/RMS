using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.RMS.Model
{
    public class RoleModel
    {
        public long roleId { get; set; }
        public string roleName { get; set; }
        public RoleType roleType { get; set; }
        public int roleOrder { get; set; }
    }
}