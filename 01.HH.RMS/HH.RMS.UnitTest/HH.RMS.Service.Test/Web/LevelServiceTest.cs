using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Constant;
using System.Web;
using HH.RMS.Service.Model;
using HH.RMS.Common.Utilities;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class LevelServiceTest : TestServiceBase
    {
        private ILevelService _levelService { get; set; }
        public LevelServiceTest()
        {
            _levelService = UnityManager.instance.GetService<ILevelService>();
            ServiceLogin();
        }
        [TestMethod]
        public void QueryLevelToGrid()
        {
           var result =  _levelService.QueryLevelToGrid(null);
           Assert.AreNotEqual(result, null);
        }
        [TestMethod]
        public void QueryLevelList()
        {
            var result = _levelService.QueryLevelList();
            Assert.AreNotEqual(result, null);
        }
        [TestMethod]
        public void CreateLevel()
        {
            LevelModel model = new LevelModel();
            model.levelName = Guid.NewGuid().ToString("N");
            model.levelOrder = 2;
            var result = _levelService.CreateLevel(model);
            Assert.AreEqual(result, ResultType.Success);
        }
        [TestMethod]
        public void UpdateLevel()
        {
            LevelModel model = new LevelModel();
            model.id=1;
            model.levelName="test2";
            model.levelOrder=3;
            var result = _levelService.UpdateLevel(model);
            Assert.AreEqual(result, ResultType.Success);
        }
        [TestMethod]
        public void QueryLevelById()
        {
            var result = _levelService.QueryLevelById(1);
            Assert.AreNotEqual(result, null);
        }
        [TestMethod]
        public void DeleteLevelByIds()
        {
            var result = _levelService.DeleteLevelByIds(new long[] { 1, 2, 3 });
            Assert.AreEqual(result, ResultType.Success);
        }
    }
}