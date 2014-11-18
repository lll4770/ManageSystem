using FineUI;
using Mi_gangBusiness;
using Mi_gangEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mi_gangUI
{
    public partial class Login : System.Web.UI.Page
    {
        private const string AdminUserSessionName = "admin.userinfo";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxCaptcha.Text != Session["CaptchaImageText"].ToString())
            {
                Alert.ShowInTop("验证码错误！");
                return;
            }

            string userNumber = tbxUserName.Text.Trim();
            string password = tbxPassword.Text.Trim();
            bool loginFlag = SetUserInfo(userNumber, password);
            if (loginFlag)
            {
                Response.Redirect("/Index.aspx");
            }
            else
            {
                Alert.ShowInTop("用户名或密码错误！", MessageBoxIcon.Error);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            InitCaptchaCode();
        }

        private void LoadData()
        {
            InitCaptchaCode();
        }

        /// <summary>
        /// 创建一个 6 位的随机数
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomCode()
        {
            string s = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                s += random.Next(10).ToString();
            }
            return s;
        }

        /// <summary>
        /// 初始化验证码
        /// </summary>
        private void InitCaptchaCode()
        {
            // 创建一个 6 位的随机数并保存在 Session 对象中
            Session["CaptchaImageText"] = GenerateRandomCode();
            imgCaptcha.ImageUrl = "~/captcha/captcha.ashx?w=150&h=30&t=" + DateTime.Now.Ticks;
        }

        public bool SetUserInfo(string userNumber, string password)
        {
            MGUserBusiness userBusiness = new MGUserBusiness();
            UserInfo user = userBusiness.UserLogin(userNumber, password);
            if (user!=null)
            {
                Session[AdminUserSessionName] = user;
                //验证通过
                HttpCookie userCookie = new HttpCookie(AdminUserSessionName);
                userCookie.Values["id"] = user.userID.ToString();
                userCookie.Values["UserNumber"] = user.UserNumber;
                userCookie.Values["password"] = user.Password;
                userCookie.Values["userName"] = user.Name;
                Response.Cookies.Add(userCookie);
                return true;
            }
            return false;
        }
    }
}