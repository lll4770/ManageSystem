using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mi_gangBusiness;

namespace Mi_gangUI.BusinessManage
{
    public partial class MemberAddress : System.Web.UI.Page
    {
        private MGMemberBusiness m_MGMemberBusiness;
        public MemberAddress()
        {
            m_MGMemberBusiness = new MGMemberBusiness();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["memberid"] != null) {
                    string memberid = Request["memberid"];
                    BindGrid(Convert.ToInt32(memberid));
                }
            }
        }

        private void BindGrid(int memberid)
        {
            Grid1.RecordCount = GetMemberLocationCount(memberid);

            DataTable dtlog = GetmemberAddressList(memberid);
            Grid1.DataSource = dtlog;
            Grid1.DataBind();
        }

        private DataTable GetmemberAddressList(int memberid)
        {
            return m_MGMemberBusiness.GetMemberAddressByMemberID(memberid);
        }

        private int GetMemberLocationCount(int memberid)
        {
            return m_MGMemberBusiness.GetMemberLocationCount(memberid);
        }
    }
}