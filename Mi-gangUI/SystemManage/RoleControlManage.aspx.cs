using FineUI;
using Mi_gangBusiness;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class RoleControlManage : BasePage
    {
        private MGRoleBusiness m_MGRoleBusiness;

        public RoleControlManage() {
            m_MGRoleBusiness = new MGRoleBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["userId"] != null) {
                    txt_roleType.Text = "1";//表示用户
                    txt_HiddenID.Text = Request["userId"].ToString();
                }
                if (Request["buttonid"] != null) {
                    txt_roleType.Text = "2";//表示按钮
                    txt_HiddenID.Text = Request["buttonid"].ToString();
                }
                BindCheckRole(Convert.ToInt32(txt_roleType.Text), Convert.ToInt32(txt_HiddenID.Text));
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            
            string[] roleList = chk_RoleList.SelectedValueArray;
            if (roleList.Length == 0) return;
            int objectid = Convert.ToInt32(txt_HiddenID.Text.Trim());
            if (txt_roleType.Text == "1") { 
                //用户角色
                m_MGRoleBusiness.ManageRoleUser(objectid, roleList);
                PageContext.RegisterStartupScript("parent.__doPostBack('','UserDetailClose');");
            }
            if (txt_roleType.Text == "2") { 
                //按钮
                m_MGRoleBusiness.ManageRoleButton(objectid, roleList);
                PageContext.RegisterStartupScript("parent.__doPostBack('','ButtonDetailClose');");
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void BindCheckRole(int type,int hiddenID)
        {
            chk_RoleList.DataTextField = "name";
            chk_RoleList.DataValueField = "id";
            chk_RoleList.DataSource = GetRoleList();
            chk_RoleList.DataBind();

            
            DataTable dt = new DataTable();
            if (type == 1) {
                dt = m_MGRoleBusiness.GetUserRoleByUserID(hiddenID);

            } if (type == 2) {
                dt = m_MGRoleBusiness.GetButtonRoleByButtonID(hiddenID);
            }
            if (dt != null && dt.Rows.Count>0) {
                string[] roles = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++) {
                    roles[i] = dt.Rows[i]["roleid"].ToString();
                }
                chk_RoleList.SelectedValueArray = roles;
            }
           
        }

        private IList<Role> GetRoleList()
        {
            IList<Role> roleList = new List<Role>();
            DataTable dt = m_MGRoleBusiness.GetRoleActiveList();
            if (null != dt && dt.Rows.Count > 0) {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    Role item = new Role
                    {
                        id = dt.Rows[i]["RoleID"].ToString(),
                        name = dt.Rows[i]["Name"].ToString()
                    };
                    roleList.Add(item);
                }
            }
            return roleList;
        }
    }


    public class Role
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}