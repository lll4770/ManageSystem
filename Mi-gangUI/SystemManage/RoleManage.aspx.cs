using FineUI;
using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.SystemManage
{
    public partial class RoleManage : BasePage
    {
        private MGRoleBusiness m_MGRoleBusiness;

        public RoleManage()
        {
            m_MGRoleBusiness = new MGRoleBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindGrid();
                
            }
            if (GetRequestEventArgument() == "RoleDetailClose")
            {
                BindGrid();
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string roleID = Grid1.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/RoleDetail.aspx?roleID={0}", roleID);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl));
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string roleID = Grid1.DataKeys[selectedIndex][0].ToString();
            m_MGRoleBusiness.DeleteRoleByID(Convert.ToInt32(roleID));
            BindGrid();
            
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            Grid1.RecordCount = GetTotalCount();

            DataTable dtRole = GetRoleList(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtRole;
            Grid1.DataBind();
        }

        private DataTable GetRoleList(int pageIndex,int pageSize)
        {
            string roleName = txt_roleName.Text.Trim();
            return m_MGRoleBusiness.GetRoleList(pageIndex, pageSize, roleName);
        }
        private int GetTotalCount()
        {
            string roleName = txt_roleName.Text.Trim();
            return m_MGRoleBusiness.GetTotalCount(roleName);
        }
        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','RoleDetailClose');");
        }

        protected void btn_modifyStatus_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string roleID = Grid1.DataKeys[selectedIndex][0].ToString();
            string statusID = Grid1.DataKeys[selectedIndex][2].ToString();
           // m_MGRoleBusiness.UpdateRoleStatusByID(statusID, Convert.ToInt32(roleID));
            BindGrid();
        }

        protected void btn_ModifyMenu_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string roleID = Grid1.DataKeys[selectedIndex][0].ToString();
            PageContext.RegisterStartupScript(Window1.GetShowReference(string.Format("~/SystemManage/MenuTree.aspx?roleID={0}",roleID),
                "菜单权限",600,600));
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            string openUrl = "~/SystemManage/RoleDetail.aspx";
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl));
        }

    }
}