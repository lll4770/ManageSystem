using FineUI;
using Mi_gangBusiness;
using System;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class MenuDetail : BasePage
    {
        private MGMenuBusiness m_MenuBusiness;

        public MenuDetail()
        {
            m_MenuBusiness = new MGMenuBusiness ();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_parentName.Items.Insert(0, new FineUI.ListItem("根节点","-1"));
                DataTable dtParentMenu = GetParentMenu();
                if (dtParentMenu != null && dtParentMenu.Rows.Count > 0) {
                    for (int i = 0; i < dtParentMenu.Rows.Count; i++) {
                        ddl_parentName.Items.Insert(i+1, new FineUI.ListItem(dtParentMenu.Rows[i]["Name"].ToString(),
                            dtParentMenu.Rows[i]["MenuID"].ToString()));
                    }
                }

                if (Request["menuid"] != null)
                {
                    int menuId = Convert.ToInt32(Request["menuid"]);
                    txt_MenuId.Text = menuId.ToString();
                    DataTable dtMenu = m_MenuBusiness.GetMenuInfoByMenuID(menuId);
                    if (dtMenu != null && dtMenu.Rows.Count > 0)
                    {
                        if (dtMenu.Rows[0]["ParentID"].ToString() == string.Empty || dtMenu.Rows[0]["ParentID"].ToString() == "-1")
                            ddl_parentName.SelectedIndex = 0;
                        else
                            ddl_parentName.SelectedValue = dtMenu.Rows[0]["ParentID"].ToString();

                        txt_MenuName.Text = dtMenu.Rows[0]["Name"].ToString();
                        txt_MenuUrl.Text = dtMenu.Rows[0]["Url"].ToString();
                        ck_menuValid.Checked = dtMenu.Rows[0]["Valid"].ToString() == "0" ? false : true;
                        txt_MenuSort.Text = dtMenu.Rows[0]["orderID"].ToString();
                    }
                }
                
            }
            
        }

        private DataTable GetParentMenu()
        {
            return m_MenuBusiness.GetParentMenu();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_MenuId.Text == string.Empty)//新增
            {
                m_MenuBusiness.InsertMenu(txt_MenuName.Text,Convert.ToInt32(txt_MenuSort.Text), 
                    Convert.ToInt32(ddl_parentName.SelectedValue), txt_MenuUrl.Text, ck_menuValid.Checked==true ? 1 : 0);
            }
            else {  //编辑
                m_MenuBusiness.UpdateMenuByMenuID(Convert.ToInt32(txt_MenuId.Text),txt_MenuName.Text,
                    txt_MenuSort.Text==string.Empty?0:Convert.ToInt32(txt_MenuSort.Text),
                        Convert.ToInt32(ddl_parentName.SelectedValue), txt_MenuUrl.Text, ck_menuValid.Checked == true ? 1 : 0);
            }
            PageContext.RegisterStartupScript("parent.__doPostBack('','MenuDetailClose');");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}