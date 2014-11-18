using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Mi_gangBusiness;

namespace Mi_gangUI.BusinessManage
{
    public partial class AnnoucementDetail : System.Web.UI.Page
    {
        private MGAnnouncementBusiness m_MGAnnouncementBusiness;
        public AnnoucementDetail()
        {
            m_MGAnnouncementBusiness = new MGAnnouncementBusiness();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DataTable dtType = m_MGAnnouncementBusiness.GetAnnouncementType();
                if (null != dtType && dtType.Rows.Count > 0) {
                    for (int i = 0; i < dtType.Rows.Count; i++) {
                        ddl_AnnounceType.Items.Insert(i, new FineUI.ListItem(dtType.Rows[i]["Value"].ToString(),
                            dtType.Rows[i]["AnnouncementTypeID"].ToString()));
                    }
                }

                if (Request["id"] != null) {
                    string id = Request["id"];
                    DataTable dt = m_MGAnnouncementBusiness.GetAnnouncementByID(Convert.ToInt32(id));
                    if (dt != null && dt.Rows.Count > 0) {
                        txt_ID.Text = dt.Rows[0]["id"].ToString();
                        txt_MemberID.Text = dt.Rows[0]["MemberID"].ToString();
                        txt_StartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["ValidDateFrom"].ToString());
                        txt_EndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["ValidDateTo"].ToString());
                        txt_Content.Text = dt.Rows[0]["Content"].ToString();
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ID.Text))//新增
            {
                m_MGAnnouncementBusiness.InsertAnnouncement(txt_Content.Text.Trim(), Convert.ToInt32(txt_MemberID.Text.Trim()),
                    Convert.ToInt32(ddl_AnnounceType.SelectedValue), Convert.ToDateTime(txt_StartDate.Text), Convert.ToDateTime(txt_EndDate.Text));
            }
            else {
                m_MGAnnouncementBusiness.UpdateAnnouncementByID(txt_Content.Text.Trim(), Convert.ToInt32(txt_MemberID.Text.Trim()),
                    Convert.ToInt32(ddl_AnnounceType.SelectedValue), Convert.ToDateTime(txt_StartDate.Text), 
                    Convert.ToDateTime(txt_EndDate.Text),Convert.ToInt32(txt_ID.Text));
            }
            PageContext.RegisterStartupScript("parent.__doPostBack('','AnnouncementDetailClose');");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}