using Mi_gangBusiness;
using Mi_gangEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Mi_gangUI
{
    public class BasePage : System.Web.UI.Page
    {
        public UserInfo CurrentAdminUser = null;
        public const string AdminUserSessionName = "admin.userinfo";

        public BasePage()
        {
            this.Load += new EventHandler(pages_Load);
        }
        public void pages_Load(object serder, EventArgs e)
        {
            GetCurrentUser();
            if (this.CurrentAdminUser == null) {
                Response.Redirect("login.aspx");
            }
        }

        public void GetCurrentUser()
        {
            if (this.CurrentAdminUser == null)
            {
                object cacheResult = Session[AdminUserSessionName];
                UserInfo user = cacheResult as UserInfo;
                if (user != null && user.userID > 0)
                {
                    this.CurrentAdminUser = user;
                }
                else if (Request.Cookies[AdminUserSessionName] != null) {
                    HttpCookie userCookie = Request.Cookies[AdminUserSessionName];
                    string userid = userCookie.Values["id"];
                    string usernames = userCookie.Values["username"];
                    string passwords = userCookie.Values["password"];
                    string userNumbers = userCookie.Values["UserNumber"];
                    this.CurrentAdminUser = new UserInfo
                    {
                        userID = Convert.ToInt32(userid),
                        UserNumber = userNumbers,
                        Password = passwords,
                        Name = usernames
                    };
                }
            }
        }

        public bool logOutUser()
        {
            Session[AdminUserSessionName] = null;

            //如果选中记住我，则记录cookie信息
            string sign = string.Empty;
            HttpCookie userCookie = new HttpCookie(AdminUserSessionName);
            userCookie.Values["id"] = null;
            userCookie.Values["username"] = null;
            userCookie.Values["password"] = null;
            userCookie.Values["UserNumber"] = null;
            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userCookie);
            return true;
        }
    }
}