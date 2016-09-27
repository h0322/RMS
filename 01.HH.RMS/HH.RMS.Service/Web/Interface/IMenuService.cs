﻿using HH.RMS.Entity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface IMenuService
    {
        List<MenuEntity> QueryMenuALL();
        string GetMenuString();
    }
}
