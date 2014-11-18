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
    public partial class MemberLevelManage : System.Web.UI.Page
    {
        private MGMemberBusiness m_MGMemberBusiness;
        public MemberLevelManage()
        {
            m_MGMemberBusiness = new MGMemberBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindGrid();
                btn_Add.OnClientClick = Window1.GetShowReference("~/BusinessManage/LevelDetail.aspx", "等级新增");
            }
            if (GetRequestEventArgument() == "LevelDetailClose")
            {
                BindGrid();
            }
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            PageContext.RegisterStartupScript("parent.__doPostBack('','LevelDetailClose');");
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string id = Grid2.DataKeys[selectedIndex][0].ToString();
            m_MGMemberBusiness.DelMemberGradeByID(Convert.ToInt32(id));
            BindGrid();
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            int selectedIndex = Grid2.SelectedRowIndex;
            if (selectedIndex == -1) return;
            string id = Grid2.DataKeys[selectedIndex][0].ToString();
            string openUrl = string.Format("~/BusinessManage/LevelDetail.aspx?id={0}", id);
            PageContext.RegisterStartupScript(Window1.GetShowReference(openUrl, "等级修改"));
        }

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void BindGrid()
        {
            Grid2.RecordCount = GetMemberGradeCount();

            DataTable dtMemberGrade = GetMemberGradeList(Grid2.PageIndex, Grid2.PageSize);
            Grid2.DataSource = dtMemberGrade;
            Grid2.DataBind();
        }

        private DataTable GetMemberGradeList(int pageIndex, int pageSize)
        {
            return m_MGMemberBusiness.GetMemberGradeList(pageIndex, pageSize);
        }

        private int GetMemberGradeCount()
        {
            return m_MGMemberBusiness.GetMemberGradeCount();
        }

        private string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }
    }
}