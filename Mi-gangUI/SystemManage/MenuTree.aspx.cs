using FineUI;
using Mi_gangBusiness;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mi_gangUI.SystemManage
{
    public partial class MenuTree : BasePage
    {
        private MGMenuBusiness m_MGMenuBusiness;
        public MenuTree()
        {
            m_MGMenuBusiness = new MGMenuBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["roleID"] != null)
                {
                    txt_roleID.Text = Request["roleID"].ToString();
                }
                LoadMenuData();

            }
        }

        protected void Tree1_NodeCheck(object sender, FineUI.TreeCheckEventArgs e)
        {

        }

        private void ResolveSubTree(DataRow dataRow, FineUI.TreeNode treeNode)
        {
            int roleID = Convert.ToInt32(txt_roleID.Text);
            DataTable dtroleMenu = GetMenuInfoByRoleID(roleID);
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.NodeID = row["MenuID"].ToString();
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent = true;
                    if (dtroleMenu != null && dtroleMenu.Rows.Count > 0) {
                        for (int i = 0; i < dtroleMenu.Rows.Count; i++) {
                            if (dtroleMenu.Rows[i]["menuID"].ToString() == row["MenuID"].ToString()) { node.Checked = true; }
                        }
                    }

                    treeNode.Nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }
        }


        private void LoadMenuData()
        {
            DataTable dtMenu = GetMenuTable();

            DataSet ds = new DataSet();
            ds.Tables.Add(dtMenu);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["MenuID"], ds.Tables[0].Columns["ParentId"]);

            int roleID = Convert.ToInt32(txt_roleID.Text);
            DataTable dtroleMenu = GetMenuInfoByRoleID(roleID);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("ParentId"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.NodeID = row["MenuID"].ToString();
                    node.EnableCheckBox = true;
                    node.Expanded = true;
                    if (dtroleMenu != null && dtroleMenu.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtroleMenu.Rows.Count; i++)
                        {
                            if (dtroleMenu.Rows[i]["menuID"].ToString() == row["MenuID"].ToString()) { node.Checked = true; }
                        }
                    }
                    
                    Tree1.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }

        private DataTable GetMenuTable()
        {
            return m_MGMenuBusiness.GetMenuInfo();
        }

        private DataTable GetMenuInfoByRoleID(int roleID)
        {
            return m_MGMenuBusiness.GetMenuInfoByRoleID(roleID);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            FineUI.TreeNode[] nodes = Tree1.GetCheckedNodes();
            IList<string> menuIDList = new List<string>();
            if (nodes.Length > 0)
            {
                foreach (FineUI.TreeNode node in nodes)
                {
                    menuIDList.Add(node.NodeID);
                }
            }
            int roleID = Convert.ToInt32(txt_roleID.Text);
            bool result = m_MGMenuBusiness.UpdateMenuInfoByRoleID(roleID, menuIDList);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}