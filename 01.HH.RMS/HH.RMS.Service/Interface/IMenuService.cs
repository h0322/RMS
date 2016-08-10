using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Interface
{
    public interface IMenuService
    {
        List<MenuEntity> QueryMenuALL();
        string GetMenuString(long menuId = 0);
    }
}
