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
    public partial class LevelDetail : System.Web.UI.Page
    {
        private MGMemberBusiness m_MGMemberBusiness;
        public LevelDetail() { m_MGMemberBusiness = new MGMemberBusiness(); }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["id"] != null)
                {
                    int gradeID = Convert.ToInt32(Request["id"]);
                    DataTable dt = m_MGMemberBusiness.GetMemberGradeByID(gradeID);
                    if (null != dt && dt.Rows.Count > 0) {
                        txt_ID.Text = dt.Rows[0]["ID"].ToString();
                        txt_Grade.Text = dt.Rows[0]["Grade"].ToString();
                        txt_orderID.Text = dt.Rows[0]["OrderID"].ToString();
                        txt_Points.Text = dt.Rows[0]["Points"].ToString();
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ID.Text))
            {
                //新增
                m_MGMemberBusiness.InsertMemberGrade(txt_Grade.Text.Trim(),Convert.ToInt32(txt_Points.Text.Trim()),
                    Convert.ToInt32(txt_orderID.Text.Trim()));
            }
            else { 
                //保存
                m_MGMemberBusiness.UpdateMemberGradeByID(Convert.ToInt32(txt_ID.Text.Trim()),txt_Grade.Text.Trim(),Convert.ToInt32(txt_Points.Text.Trim()),
                    Convert.ToInt32(txt_orderID.Text.Trim()));
            }
            PageContext.RegisterStartupScript("parent.__doPostBack('','LevelDetailClose');");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}