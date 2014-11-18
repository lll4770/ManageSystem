using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.LogManage
{
    public partial class PointsLog : BasePage
    {
         private MGLogBusiness m_MGLogBusiness;
         public PointsLog()
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
            Grid1.RecordCount = GetPointsChangeLogCount();

            DataTable dtlog = GetPointsChangeLogList(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtlog;
            Grid1.DataBind();
        }

        private DataTable GetPointsChangeLogList(int pageIndex, int pageSize)
        {
            return m_MGLogBusiness.GetPointsChangeLogList(pageIndex, pageSize);
        }

        private int GetPointsChangeLogCount()
        {
            return m_MGLogBusiness.GetPointsChangeLogCount();
        }
    }
}