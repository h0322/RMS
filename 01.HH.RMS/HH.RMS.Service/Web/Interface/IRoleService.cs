using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface IRoleService
    {
        List<RoleModel> QueryRoleList();
        GridModel QueryRoleToGrid(PagerModel pager);
        ResultType CreateRole(RoleModel model);
        ResultType UpdateRole(RoleModel model);
        RoleModel QueryRoleById(long id);
        ResultType DeleteRoleByIds(long[] ids);
        ResultType UpdateMenuRoleByMenuId(MenuModel model);
        List<MenuRoleModel> QueryMenuByRoleIdList(long roleBitMap);
        ResultType UpdateMenuRole(RoleMenuModel model);
    }
}
