using FineUI;
using Mi_gangBusiness;
using System;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class UserDetail : BasePage
    {
        private MGRoleBusiness m_MGRoleBusiness;
        private MGUserBusiness m_MGUserBusiness;
        public UserDetail()
        {
            m_MGRoleBusiness = new MGRoleBusiness();
            m_MGUserBusiness = new MGUserBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtStatus = m_MGRoleBusiness.GetStatusInfo();
                if (dtStatus != null && dtStatus.Rows.Count > 0)
                {
                    for (int i = 0; i < dtStatus.Rows.Count; i++)
                    {
                        ddl_Status.Items.Insert(i, new FineUI.ListItem(dtStatus.Rows[i]["remark"].ToString(),
                            dtStatus.Rows[i]["statusid"].ToString()));
                    }
                }

                if (Request["userid"] != null)
                {
                    string userid = Request["userid"].ToString();
                    DataTable dtRole = m_MGUserBusiness.GetUserInfoByID(Convert.ToInt32(userid));
                    if (dtRole != null && dtRole.Rows.Count > 0)
                    {
                        txt_UserID.Text = dtRole.Rows[0]["userid"].ToString();
                        txt_UserNumber.Text = dtRole.Rows[0]["UserNumber"].ToString();
                        txt_Name.Text = dtRole.Rows[0]["Name"].ToString();
                        txt_Code.Text = dtRole.Rows[0]["code"].ToString();
                        txt_NickName.Text = dtRole.Rows[0]["NickName"].ToString();
                        txt_CreateDate.SelectedDate = Convert.ToDateTime(dtRole.Rows[0]["CreateDate"].ToString());
                        txt_Remark.Text = dtRole.Rows[0]["Remark"].ToString();
                        ddl_Status.SelectedValue = dtRole.Rows[0]["statusid"].ToString();
                    }
                }

            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (string.IsNullOrEmpty(txt_UserID.Text.Trim()))
            {
                //新增
                result = m_MGUserBusiness.InsertUser(txt_UserNumber.Text.Trim(), txt_Name.Text.Trim(),txt_Code.Text.Trim(),
                    txt_NickName.Text.Trim(), txt_CreateDate.Text.Trim(), Convert.ToInt32(ddl_Status.SelectedValue),txt_Remark.Text.Trim());
            }
            else
            {
                result = m_MGUserBusiness.UpdateUserByID(txt_UserNumber.Text.Trim(), txt_Name.Text.Trim(), txt_Code.Text.Trim(),
                    txt_NickName.Text.Trim(), txt_CreateDate.Text.Trim(), Convert.ToInt32(ddl_Status.SelectedValue),
                    txt_Remark.Text.Trim(), Convert.ToInt32(txt_UserID.Text.Trim()));
            }
            if (result > 0)
            {
                PageContext.RegisterStartupScript("parent.__doPostBack('','UserDetailClose');");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}