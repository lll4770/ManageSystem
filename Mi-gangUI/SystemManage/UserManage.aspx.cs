using FineUI;
using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.SystemManage
{
    public partial class UserManage : BasePage
    {
        private MGUserBusiness m_MGUserBusiness;
        private MGRoleBusiness m_MGRoleBusiness;
        public UserManage()
        {
            m_MGUserBusiness = new MGUserBusiness();
            m_MGRoleBusiness = new MGRoleBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindGrid();

                btn_Add.OnClientClick = Window1.GetShowReference("~/SystemManage/UserDetail.aspx", "用户详情");
              
            }
            if (GetRequestEventArgument() == "UserDetailClose")
            {
                BindGrid();
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string UserID = Grid2.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/UserDetail.aspx?userId={0}", UserID);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl));
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string userid = Grid2.DataKeys[selectedIndex][0].ToString();
            m_MGUserBusiness.DelUserByUserID(Convert.ToInt32(userid));
            BindGrid();
        }

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','UserDetailClose');");
        }

        private void BindGrid()
        {
            Grid2.RecordCount = GetUserCount();

            DataTable dtRole = GetUserList(Grid2.PageIndex, Grid2.PageSize);
            Grid2.DataSource = dtRole;
            Grid2.DataBind();
        }

        private DataTable GetUserList(int pageIndex, int pageSize)
        {
            string userNumber = txt_UserNumber.Text.Trim();
            string code = txt_Code.Text.Trim();
            string name = txt_Name.Text.Trim();
            return m_MGUserBusiness.GetUserList(pageIndex, pageSize, userNumber, code, name);
        }

        private int GetUserCount()
        {
            string userNumber = txt_UserNumber.Text.Trim();
            string code = txt_Code.Text.Trim();
            string name = txt_Name.Text.Trim();
            return m_MGUserBusiness.GetUserCount(userNumber, code, name);
        }

        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }

        protected void btn_SetRole_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string UserID = Grid2.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/RoleControlManage.aspx?userId={0}", UserID);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl));
            
        }

        public string GetRoleNameInfo(string userid)
        {
            string roleName = string.Empty;
            DataTable dtRole = m_MGRoleBusiness.GetRoleInfoByUserID(Convert.ToInt32(userid));
            if (dtRole != null && dtRole.Rows.Count > 0) {
                for (int i = 0; i < dtRole.Rows.Count; i++) {
                    roleName += dtRole.Rows[i]["name"].ToString() + "|";
                }
                roleName = roleName.TrimEnd('|');
            }
            return roleName;
        }

        protected void btn_ModifyUserPassword_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string UserID = Grid2.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/ModifyPassword.aspx?userId={0}", UserID);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl,"修改密码"));
        }
    }
}