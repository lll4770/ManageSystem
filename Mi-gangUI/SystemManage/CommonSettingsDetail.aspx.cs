using FineUI;
using Mi_gangBusiness;
using System;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class CommonSettingsDetail : BasePage
    {
        private MGCommonSettingBusiness m_MGCommonSettingBusiness;
        public CommonSettingsDetail()
        {
            m_MGCommonSettingBusiness = new MGCommonSettingBusiness ();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["ID"] != null) {
                    txt_ID.Text = Request["ID"].ToString();
                    DataTable dtCommonSetting = m_MGCommonSettingBusiness.GetCommonSettinsByID(Convert.ToInt32(txt_ID.Text));
                    if (null != dtCommonSetting && dtCommonSetting.Rows.Count > 0) {
                        txt_Name.Text = dtCommonSetting.Rows[0]["Name"].ToString();
                        txt_Value.Text = dtCommonSetting.Rows[0]["value"].ToString();
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ID.Text.Trim()))
            {//新增 
                m_MGCommonSettingBusiness.InsertCommonSetting(txt_Name.Text.Trim(), txt_Value.Text.Trim());
            }
            else {
                m_MGCommonSettingBusiness.UpdateCommonSettingByID(txt_Name.Text.Trim(), txt_Value.Text.Trim(), Convert.ToInt32(txt_ID.Text.Trim()));
            }
            PageContext.RegisterStartupScript("parent.__doPostBack('','CommonSettingsDetailClose');");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}