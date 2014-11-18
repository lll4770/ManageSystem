using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.LogManage
{
    public partial class CreditLog : BasePage
    {
        private MGLogBusiness m_MGLogBusiness;
        public CreditLog()
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
            Grid1.RecordCount = GetCreditsChangeLogCount();

            DataTable dtlog = GetCreditsChangeLogList(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtlog;
            Grid1.DataBind();
        }

        private DataTable GetCreditsChangeLogList(int pageIndex, int pageSize)
        {
            return m_MGLogBusiness.GetCreditsChangeLogList(pageIndex, pageSize);
        }

        private int GetCreditsChangeLogCount()
        {
            return m_MGLogBusiness.GetCreditsChangeLogCount();
        }
    }
}