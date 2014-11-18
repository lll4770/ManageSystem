using FineUI;
using Mi_gangBusiness;
using System;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class ButtonDetail : BasePage
    {
        private MGMenuBusiness m_MGMenuBusiness;
        private MGButtonBusiness m_MGButtonBusiness;
        public ButtonDetail()
        {
            m_MGMenuBusiness = new MGMenuBusiness();
            m_MGButtonBusiness = new MGButtonBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtMenu = GetMenuInfo();
                if (dtMenu != null && dtMenu.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMenu.Rows.Count; i++)
                    {
                        ddl_MenuName.Items.Insert(i, new FineUI.ListItem(dtMenu.Rows[i]["Name"].ToString(),
                            dtMenu.Rows[i]["MenuID"].ToString()));
                    }
                }

                if (Request["buttonid"] != null)
                {
                    int buttonID = Convert.ToInt32(Request["buttonid"]);
                    txt_ButtonID.Text = buttonID.ToString();
                    DataTable dtButton = m_MGButtonBusiness.GetButtonInfoByID(buttonID);
                    if (dtButton != null && dtButton.Rows.Count > 0)
                    {
                        
                        ddl_MenuName.SelectedValue = dtButton.Rows[0]["MenuID"].ToString();

                        txt_ButtonName.Text = dtButton.Rows[0]["Name"].ToString();
                        ck_buttonValid.Checked = dtButton.Rows[0]["IsAuthority"].ToString().ToLower() == "false" ? false : true;
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_ButtonID.Text.Trim() == string.Empty)//新增
            {
                m_MGButtonBusiness.InsertButton(Convert.ToInt32(ddl_MenuName.SelectedValue), txt_ButtonName.Text,
                    ck_buttonValid.Checked == true ? 1 : 0);
            }
            else
            {  //编辑
                m_MGButtonBusiness.UpdateButtonInfoByID(Convert.ToInt32(txt_ButtonID.Text), Convert.ToInt32(ddl_MenuName.SelectedValue),
                    txt_ButtonName.Text, ck_buttonValid.Checked == true ? 1 : 0);
            }
            PageContext.RegisterStartupScript("parent.__doPostBack('','ButtonDetailClose');");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private DataTable GetMenuInfo()
        {
            return m_MGMenuBusiness.GetMenuInfo();
        }
    }
}