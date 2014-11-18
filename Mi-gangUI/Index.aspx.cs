using System;
using System.Data;
using FineUI;
using Mi_gangBusiness;

namespace Mi_gangUI
{
    public partial class Index : BasePage
    {
        private MGRoleBusiness m_MGRoleBusiness;
        private MGMenuBusiness m_MGMenuBusiness;
        public Index()
        {
            m_MGRoleBusiness = new MGRoleBusiness();
            m_MGMenuBusiness = new MGMenuBusiness();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                //绑定用户权限
                int userid = CurrentAdminUser.userID;
                LoadMenuData(userid);
            }
        }

        protected void btn_Exit_Click(object sender, EventArgs e)
        {
            if (logOutUser())
                Response.Redirect("Login.aspx");
        }

        protected void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            if (CurrentAdminUser != null)
            {
                string openUrl = string.Format("~/SystemManage/ModifyPassword.aspx?userId={0}", CurrentAdminUser.UserNumber);
                PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl, "修改密码"));
            }
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void LoadMenuData(int userid)
        {
            DataTable dtRole = m_MGRoleBusiness.GetRoleInfoByUserID(userid);
            string roles = string.Empty;
            if (null != dtRole && dtRole.Rows.Count > 0)
            {
                for (int i = 0; i < dtRole.Rows.Count; i++)
                {
                    roles += dtRole.Rows[i]["RoleID"].ToString() + ",";
                }
                roles = roles.TrimEnd(',');
            }
            if (string.IsNullOrEmpty(roles))
                return;

            DataTable dtMenu = m_MGMenuBusiness.GetMenuInfoByRoleIDs(roles);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtMenu);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["MenuID"], ds.Tables[0].Columns["ParentId"]);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("ParentId"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.NodeID = row["MenuID"].ToString();
                    node.Expanded = false;
                    leftMenuTree.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }

        private void ResolveSubTree(DataRow dataRow, FineUI.TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                treeNode.Expanded = false;
                foreach (DataRow row in rows)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.NodeID = row["MenuID"].ToString();
                    node.NavigateUrl = row["URL"].ToString() + "?memuid=" + row["MenuID"].ToString();
                    treeNode.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }
    }
}