using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HH.RMS.WebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Register();
        }
        public void Register()
        {
            Register.RegisterRequest dd = new Register.RegisterRequest();
            dd.UserInfo = new Register.RegisterUserInfoModel { name = "1", birthDay = 1, birthMonth = 2, birthYear = 1999, cityId = 1, firstName = "a", gender = 1, lastName = "22", mobile = "13321216665", openId = "12313112223", provinceId = 27 };
            //Webservice_Occitane.RegisterService:registerRequest.AppID:wx4a63496668c5dac4;RandomString:DdeVPcgT7cn3tcj8q2uPHmCe9EaW8yZd;SecurityKey:0191703a8e4163942bd51b1290be28e2;Signature:14fad469069f475313e1d4ee445fac44f7c616c8
            Register.RegisterRequest request = new Register.RegisterRequest { AppID = "wx4a63496668c5dac4", SecurityKey = "0191703a8e4163942bd51b1290be28e2", RandomString = "BkxB2EMDyUr2TSxQgOZ8UA1BNLmtfAWq", Signature = "62ecfb08fd7324f8a7f578388fded1aca71b0e23", UserInfo = dd.UserInfo };
            Register.Webservice_OccitaneClient client = new Register.Webservice_OccitaneClient();
            var ss = client.RegisterService(request);
        }
        public void GetMemberInfo()
        {
            Register.RequestByOpenId request = new Register.RequestByOpenId();
            request.AppID = "wx4a63496668c5dac4";
            request.SecurityKey = "0191703a8e4163942bd51b1290be28e2";
            request.RandomString = "BkxB2EMDyUr2TSxQgOZ8UA1BNLmtfAWq";
            request.RandomString = "679f890c093a543bdb2afa715a74b7e0298d691b";
            request.OpenID = "o2Xz5s586G_X5XgK961ZESjya020";
            Register.Webservice_OccitaneClient client = new Register.Webservice_OccitaneClient();
            var ss = client.GetMemberInfoByOpenId(request);
            
        }
    }
}