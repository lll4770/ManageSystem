using FineUI;
using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.SystemManage
{
    public partial class ButtonManage : BasePage
    {
        private MGButtonBusiness m_MGButtonBusiness;
        private MGRoleBusiness m_MGRoleBusiness;
        public ButtonManage()
        {
            m_MGButtonBusiness = new MGButtonBusiness();
            m_MGRoleBusiness = new MGRoleBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string buttonName = txt_buttonName.Text.Trim();
            if (!IsPostBack) {
                BindGrid(buttonName);
                btn_add.OnClientClick = Window1.GetShowReference("~/SystemManage/ButtonDetail.aspx", "新增按钮");
            }
            if (GetRequestEventArgument() == "ButtonDetailClose")
            {
                BindGrid(buttonName);
            }
        }

        private void BindGrid(string buttonName)
        {
            Grid1.RecordCount = GetTotalCount(buttonName);

            DataTable dtMenu = GetMenuInfo(Grid1.PageIndex, Grid1.PageSize, buttonName);
            Grid1.DataSource = dtMenu;
            Grid1.DataBind();
        }

        private int GetTotalCount(string buttonName)
        {
            return m_MGButtonBusiness.GetButtonCount(buttonName);
        }

        private DataTable GetMenuInfo(int pageIndex, int pageSize, string buttonName)
        {
            return m_MGButtonBusiness.GetButtonList(pageIndex, pageSize, buttonName);
        }

        public string GetRoleName(string RoleIDs)
        {
            if(string.IsNullOrEmpty(RoleIDs))
                return string.Empty;

            if (RoleIDs.Contains("|"))
            {
                string[] roldInfo = RoleIDs.Split('|');
                string roleNames = string.Empty;
                for (int i = 0; i < roldInfo.Length; i++) {
                    roleNames += m_MGRoleBusiness.GetRoleNameByID(Convert.ToInt32(roldInfo[i]))+"|";
                }
                return roleNames.TrimEnd('|');
            }
            else {
                return GetRoleNameByID(Convert.ToInt32(RoleIDs));
            }
        }

        private string GetRoleNameByID(int roleID)
        {
            return m_MGRoleBusiness.GetRoleNameByID(roleID);
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string buttonName = txt_buttonName.Text.Trim();
            string buttonID = Grid1.DataKeys[selectedIndex][0].ToString();
            m_MGButtonBusiness.DelButtonByID(Convert.ToInt32(buttonID));
            BindGrid(buttonName);
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string buttonID = Grid1.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/ButtonDetail.aspx?buttonid={0}", buttonID);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl));
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','ButtonDetailClose');");
        }

        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            string buttonName = txt_buttonName.Text.Trim();
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid(buttonName);
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string buttonName = txt_buttonName.Text.Trim();
            BindGrid(buttonName);
        }

        protected void btn_SetRole_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string buttonid = Grid1.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/RoleControlManage.aspx?buttonid={0}", buttonid);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl,"按钮角色设置"));
        }

        public string GetRoleNameInfo(string buttonid)
        {
            string roleName = string.Empty;
            DataTable dtRole = m_MGRoleBusiness.GetRoleInfoByButtonID(Convert.ToInt32(buttonid));
            if (dtRole != null && dtRole.Rows.Count > 0) {
                for (int i = 0; i < dtRole.Rows.Count; i++) {
                    roleName += dtRole.Rows[i]["name"].ToString() + "|";
                }
                roleName = roleName.TrimEnd('|');
            }
            return roleName;
        }
    }
}