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
    public partial class MemberManage : System.Web.UI.Page
    {
        private MGMemberBusiness m_MGMemberBusiness;
        public MemberManage()
        {
            m_MGMemberBusiness = new MGMemberBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindGrid();
                btn_Add.OnClientClick = Window1.GetShowReference("~/BusinessManage/MemberDetail.aspx", "会员新增");
            }
            if (GetRequestEventArgument() == "MemberDetailClose")
            {
                BindGrid();
            }
        }

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string memberid = Grid2.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/BusinessManage/MemberDetail.aspx?memberid={0}", memberid);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl,"修改会员信息"));
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string memberid = Grid2.DataKeys[selectedIndex][0].ToString();
            m_MGMemberBusiness.DeleteMemberByMemberID(Convert.ToInt32(memberid));
            BindGrid();
        }

        protected void btn_Address_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string memberid = Grid2.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/BusinessManage/MemberAddress.aspx?memberid={0}", memberid);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl, "会员地址", 1000, 650));
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','MemberDetailClose');");
        }

        protected void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void BindGrid()
        {
            Grid2.RecordCount = GetMemberCount();

            DataTable dtRole = GetMemberList(Grid2.PageIndex, Grid2.PageSize);
            Grid2.DataSource = dtRole;
            Grid2.DataBind();
        }

        private DataTable GetMemberList(int pageIndex, int pageSize)
        {
            string userName = txt_Name.Text.Trim();
            string code = txt_Code.Text.Trim();
            string realName = txt_RealName.Text.Trim();
            return m_MGMemberBusiness.GetMemberList(pageIndex, pageSize, userName,code,realName);
        }

        private int GetMemberCount()
        {
            string userName = txt_Name.Text.Trim();
            string code = txt_Code.Text.Trim();
            string realName = txt_RealName.Text.Trim();
            return m_MGMemberBusiness.GetMemberCount(userName,code,realName);
        }

        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }

        
    }
}