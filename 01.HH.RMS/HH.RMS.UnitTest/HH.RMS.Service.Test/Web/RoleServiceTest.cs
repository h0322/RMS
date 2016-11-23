using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Model;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class RoleServiceTest : TestServiceBase
    {
        private IRoleService _roleService { get; set; }
        public RoleServiceTest()
        {
            _roleService = UnityManager.instance.GetService<IRoleService>();
            ServiceLogin();
        }
        [TestMethod]
        public void DeleteRoleByIds()
        {
            _roleService.DeleteRoleByIds(new long[] { 9 });
        }
        [TestMethod]
        public void CreateRole()
        {
            RoleModel model = new RoleModel();
            long[] bitMap = RoleModel.CurrentCacheList.Select(m => m.bitMap).ToArray();
            model.bitMap = BitMapHelper.GetBitMap(bitMap);
            model.roleName = "test";
            model.roleOrder = 99;
            Assert.AreEqual(_roleService.CreateRole(model), ResultType.Success);
        }
        [TestMethod]
        public void UpdateRole()
        {
            RoleModel model = new RoleModel();
            model.id = 2;
            model.roleName = Guid.NewGuid().ToString("N")+"_test";
            model.roleOrder = 99;
            Assert.AreEqual(_roleService.UpdateRole(model), ResultType.Success);
        }
        [TestMethod]
        public void QueryRoleById()
        {
            Assert.AreNotEqual(_roleService.QueryRoleById(1), null);
        }
        [TestMethod]
        public void QueryMenuByRoleIdList()
        {
            Assert.AreNotEqual(_roleService.QueryMenuByRoleIdList(1),null);
        }
    }
}
