using FineUI;
using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.SystemManage
{
    public partial class AuthorizationManage : BasePage
    {
        private MGMenuBusiness m_MenuBusiness;

        public AuthorizationManage()
        {
            m_MenuBusiness = new MGMenuBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                btn_add.OnClientClick = Window1.GetShowReference("~/SystemManage/MenuDetail.aspx","新增菜单");

            }
            if (GetRequestEventArgument() == "MenuDetailClose")
            {
                BindGrid();
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void BindGrid()
        {
            Grid1.RecordCount = GetTotalCount();

            DataTable dtMenu = GetMenuInfo(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtMenu;
            Grid1.DataBind();
        }

        private DataTable GetMenuInfo(int pageIndex, int pageSize)
        {
            return m_MenuBusiness.GetMenuList(pageIndex, pageSize);
        }

        private int GetTotalCount()
        {
            return m_MenuBusiness.GetMenuCount();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string menuID = Grid1.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/MenuDetail.aspx?menuid={0}", menuID);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl));
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string menuID = Grid1.DataKeys[selectedIndex][0].ToString();
            m_MenuBusiness.DelMenuByMenuID(Convert.ToInt32(menuID));
            BindGrid();

        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','MenuDetailClose');");
        }

        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }
    }
}