using HH.RMS.Common.Unity;
using HH.RMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test
{
    public class TestServiceBase
    {
        public TestServiceBase()
        {
            new UnityService(UnityManager.instance);
        }
    }
}
