using HH.RMS.Common.Constant;
using HH.RMS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Model
{
    public class UserModel
    {
        public long userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public List<RoleModel> roleList { get; set; }

    }
}
