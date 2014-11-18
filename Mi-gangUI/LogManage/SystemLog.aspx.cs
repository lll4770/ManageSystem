using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.LogManage
{
    public partial class SystemLog : BasePage
    {
        private MGLogBusiness m_MGLogBusiness;
        public SystemLog()
        {
            m_MGLogBusiness = new MGLogBusiness ();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
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
            Grid1.RecordCount = GetSystemLogCount();

            DataTable dtlog = GetSystemLogList(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtlog;
            Grid1.DataBind();
        }

        private DataTable GetSystemLogList(int pageIndex, int pageSize)
        {
            return m_MGLogBusiness.GetSystemLogList(pageIndex, pageSize);
        }

        private int GetSystemLogCount()
        {
            return m_MGLogBusiness.GetSystemLogCount();
        }
    }
}