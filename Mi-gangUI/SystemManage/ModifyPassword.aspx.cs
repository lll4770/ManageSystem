using FineUI;
using Mi_gangBusiness;
using System;

namespace Mi_gangUI.SystemManage
{
    public partial class ModifyPassword : BasePage
    {
        private MGUserBusiness m_MGUserBusiness;
        public ModifyPassword()
        {
            m_MGUserBusiness = new MGUserBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["userid"] != null) {
                    txt_userid.Text = Request["userid"].ToString();
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string password = txt_Password.Text;
            string repassword = txt_RePassword.Text;
            if (!password.Equals(repassword))
            {
                Alert.Show("两次输入的密码不一致！", MessageBoxIcon.Warning);
                return;
            }
            m_MGUserBusiness.UpdateUserPasswordByUserid(Convert.ToInt32(txt_userid.Text.Trim()), password);
            
            PageContext.RegisterStartupScript("parent.__doPostBack('','UserDetailClose');");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}