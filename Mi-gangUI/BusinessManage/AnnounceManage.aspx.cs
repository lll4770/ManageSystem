using FineUI;
using Mi_gangBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mi_gangUI.BusinessManage
{
    public partial class AnnounceManage : System.Web.UI.Page
    {
        private MGAnnouncementBusiness m_MGAnnouncementBusiness;
        public AnnounceManage() 
        {
            m_MGAnnouncementBusiness = new MGAnnouncementBusiness(); 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindGrid();
                btn_Add.OnClientClick = Window1.GetShowReference("~/BusinessManage/AnnoucementDetail.aspx", "公告新增");
                ddl_AnnounceType.Items.Insert(0, new FineUI.ListItem("全部","0"));
                DataTable dtType = m_MGAnnouncementBusiness.GetAnnouncementType();
                if (null != dtType && dtType.Rows.Count > 0)
                {
                    for (int i = 0; i < dtType.Rows.Count; i++)
                    {
                        ddl_AnnounceType.Items.Insert(i+1, new FineUI.ListItem(dtType.Rows[i]["Value"].ToString(),
                            dtType.Rows[i]["AnnouncementTypeID"].ToString()));
                    }
                }
            }
            if (GetRequestEventArgument() == "AnnouncementDetailClose")
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
            string id = Grid2.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/BusinessManage/AnnoucementDetail.aspx?id={0}", id);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl, "修改公告信息"));
        }

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','AnnouncementDetailClose');");
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string id = Grid2.DataKeys[selectedIndex][0].ToString();
            m_MGAnnouncementBusiness.DelAnnoncementByID(Convert.ToInt32(id));
            BindGrid();
        }

        private void BindGrid()
        {
            Grid2.RecordCount = GetAnnouncementCount();

            DataTable dtRole = GetAnnouncementList(Grid2.PageIndex, Grid2.PageSize);
            Grid2.DataSource = dtRole;
            Grid2.DataBind();
        }

        private DataTable GetAnnouncementList(int pageIndex, int pageSize)
        {
            string typeid = ddl_AnnounceType.SelectedValue;
            string name = txt_Name.Text.Trim();
            string startDate = txt_StartDate.Text;
            return m_MGAnnouncementBusiness.GetAnnouncementList(pageIndex, pageSize,Convert.ToInt32(typeid),
                name,startDate);
        }

        private int GetAnnouncementCount()
        {
            string typeid = ddl_AnnounceType.SelectedValue;
            string name = txt_Name.Text.Trim();
            string startDate = txt_StartDate.Text;
            return m_MGAnnouncementBusiness.GetAnnouncementCount(Convert.ToInt32(typeid),
                name, startDate);
        }

        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }
    }
}