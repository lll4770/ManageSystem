using FineUI;
using Mi_gangBusiness;
using System;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class RoleDetail : BasePage
    {
        private MGRoleBusiness m_MGRoleBusiness;
        public RoleDetail()
        {
            m_MGRoleBusiness = new MGRoleBusiness();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DataTable dtStatus = m_MGRoleBusiness.GetStatusInfo();
                if (dtStatus != null && dtStatus.Rows.Count > 0)
                {
                    for (int i = 0; i < dtStatus.Rows.Count; i++)
                    {
                        ddl_RoleName.Items.Insert(i, new FineUI.ListItem(dtStatus.Rows[i]["remark"].ToString(),
                            dtStatus.Rows[i]["statusid"].ToString()));
                    }
                }

                if (Request["roleID"] != null) {
                    string roleID = Request["roleID"].ToString();
                    DataTable dtRole = m_MGRoleBusiness.GetRoleInfoByID(Convert.ToInt32(roleID));
                    if (dtRole != null && dtRole.Rows.Count > 0) {
                        txt_RoleName.Text = dtRole.Rows[0]["Name"].ToString();
                        txt_Remark.Text = dtRole.Rows[0]["Remark"].ToString();
                        txt_roleID.Text = dtRole.Rows[0]["RoleID"].ToString();
                        ddl_RoleName.SelectedValue = dtRole.Rows[0]["statusid"].ToString();
                    }
                }
               
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (string.IsNullOrEmpty(txt_roleID.Text.Trim()))
            {
                //新增
                result = m_MGRoleBusiness.InsertRole(txt_RoleName.Text.Trim(), txt_Remark.Text.Trim(),
                    Convert.ToInt32(ddl_RoleName.SelectedValue));
            }
            else {
                result = m_MGRoleBusiness.UpdateRoleInfoByID(txt_RoleName.Text.Trim(), txt_Remark.Text.Trim(),
                    Convert.ToInt32(txt_roleID.Text),Convert.ToInt32(ddl_RoleName.SelectedValue));
            }
            if (result > 0)
            {
                PageContext.RegisterStartupScript("parent.__doPostBack('','RoleDetailClose');");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}