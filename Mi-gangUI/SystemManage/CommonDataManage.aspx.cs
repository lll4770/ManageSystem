using FineUI;
using Mi_gangBusiness;
using System;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class CommonDataManage : BasePage
    {
        private MGCommonSettingBusiness m_MGCommonSettingBusiness;
        public CommonDataManage()
        {
            m_MGCommonSettingBusiness = new MGCommonSettingBusiness ();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindGrid();
                btn_add.OnClientClick = Window1.GetShowReference("~/SystemManage/CommonSettingsDetail.aspx", "新增菜单");
            }
            if (GetRequestEventArgument() == "CommonSettingsDetailClose")
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
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string ID = Grid1.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/SystemManage/CommonSettingsDetail.aspx?ID={0}", ID);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl));
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid1.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string ID = Grid1.DataKeys[selectedIndex][0].ToString();
            m_MGCommonSettingBusiness.DeleteCommonSettingsByID(Convert.ToInt32(ID));
            BindGrid();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','CommonSettingsDetailClose');");
        }

        private void BindGrid()
        {
            Grid1.RecordCount = GetCommonSettingsCount();

            DataTable dtCommonSetting = GetCommonSettingsInfo(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtCommonSetting;
            Grid1.DataBind();
        }

        private DataTable GetCommonSettingsInfo(int pageIndex,int pageSize)
        { 
            string name = txt_commonSettingName.Text.Trim();
            return m_MGCommonSettingBusiness.GetCommonSettingList(pageIndex, pageSize, name);
        }
        private int GetCommonSettingsCount()
        {
            string name = txt_commonSettingName.Text.Trim();
            return m_MGCommonSettingBusiness.GetCommonSettingCount(name);
        }
        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }
    }
}