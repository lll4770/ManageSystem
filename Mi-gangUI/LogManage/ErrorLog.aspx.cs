using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.LogManage
{
    public partial class ErrorLog : BasePage
    {
        private MGLogBusiness m_MGLogBusiness;
        public ErrorLog()
        {
            m_MGLogBusiness = new MGLogBusiness();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            Grid1.RecordCount = GetLogErrorCount();

            DataTable dtlog = GetLogErrorList(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtlog;
            Grid1.DataBind();
        }

        private DataTable GetLogErrorList(int pageIndex, int pageSize)
        {
            return m_MGLogBusiness.GetLogErrorList(pageIndex, pageSize);
        }

        private int GetLogErrorCount()
        {
            return m_MGLogBusiness.GetLogErrorCount();
        }
    }
}