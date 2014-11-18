using Mi_gangBusiness;
using Mi_gangUI;
using System;
using System.Data;

namespace ProjectDemo.LogManage
{
    public partial class PurchaseLog : BasePage
    {
       private MGLogBusiness m_MGLogBusiness;
       public PurchaseLog()
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
            Grid1.RecordCount = GetPurchaseLogCount();

            DataTable dtlog = GetPurchaseLogList(Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = dtlog;
            Grid1.DataBind();
        }

        private DataTable GetPurchaseLogList(int pageIndex, int pageSize)
        {
            return m_MGLogBusiness.GetPurchaseLogList(pageIndex, pageSize);
        }

        private int GetPurchaseLogCount()
        {
            return m_MGLogBusiness.GetPurchaseLogCount();
        }
    }
}