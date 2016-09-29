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
        ResultType UpdateMenuRoleById(MenuRoleModel model);
        ResultType InsertMenuRole(MenuRoleModel model);
        ResultType DeleteMenuRoleByIds(long[] ids);
        ResultType DeleteMenuRoleById(long id);
        List<MenuRoleModel> QueryMenuByRoleIdList(long roleId);
    }
}
