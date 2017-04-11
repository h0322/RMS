using HH.RMS.Common.Unity;
using HH.RMS.IService;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class MenuServiceTest : TestServiceBase
    {
        private IMenuService _menuService { get; set; }
        public MenuServiceTest()
        {
            _menuService = UnityManager.instance.GetService<IMenuService>();
            ServiceLogin();
        }
        [TestMethod]
        public void QueryMenuALL()
        {
            var result = _menuService.QueryMenuALL();
            Assert.AreNotEqual(result, null);
        }
        [TestMethod]
        public void GetMenuString()
        {
            var result = _menuService.GetMenuString();
            Assert.AreNotEqual(string.IsNullOrEmpty(result),true);
        }
    }
}
