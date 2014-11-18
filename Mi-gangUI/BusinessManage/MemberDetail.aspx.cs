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
    public partial class MemberDetail : System.Web.UI.Page
    {
        private MGRoleBusiness m_MGRoleBusiness;
        private MGMemberBusiness m_MGMemberBusiness;
        public MemberDetail()
        {
            m_MGRoleBusiness = new MGRoleBusiness();
            m_MGMemberBusiness = new MGMemberBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //用户状态填充
                DataTable dtStatus = m_MGRoleBusiness.GetStatusInfo();
                if (dtStatus != null && dtStatus.Rows.Count > 0)
                {
                    for (int i = 0; i < dtStatus.Rows.Count; i++)
                    {
                        ddl_Status.Items.Insert(i, new FineUI.ListItem(dtStatus.Rows[i]["remark"].ToString(),
                            dtStatus.Rows[i]["statusid"].ToString()));
                    }
                }
                //用户类型填充
                DataTable dtType = m_MGMemberBusiness.GetMemberTypeInfo();
                if (dtType != null && dtType.Rows.Count > 0) {
                    for (int i = 0; i < dtType.Rows.Count; i++) {
                        ddl_MemberType.Items.Insert(i, new FineUI.ListItem(dtType.Rows[i]["value"].ToString(),
                            dtType.Rows[i]["membertypeid"].ToString()));
                    }
                }

                if (Request["memberid"] != null) {
                    int memberid = Convert.ToInt32(Request["memberid"]);
                    DataTable dtmember = m_MGMemberBusiness.GetMemberInfoByMemberID(memberid);
                    if (dtmember != null && dtmember.Rows.Count>0) {
                        txt_memberID.Text = dtmember.Rows[0]["MemberID"].ToString();
                        txt_Name.Text = dtmember.Rows[0]["Name"].ToString();
                        txt_Code.Text = dtmember.Rows[0]["Code"].ToString();
                        txt_CellPhone.Text = dtmember.Rows[0]["cellphone"].ToString();
                        txt_RealName.Text = dtmember.Rows[0]["realName"].ToString();
                        txt_Mail.Text = dtmember.Rows[0]["mail"].ToString();
                        txt_WeChat.Text = dtmember.Rows[0]["weichat"].ToString();
                        txt_Points.Text = dtmember.Rows[0]["points"].ToString();
                        txt_Credits.Text = dtmember.Rows[0]["credits"].ToString();
                        ddl_Status.SelectedValue = dtmember.Rows[0]["statusid"].ToString();
                        ddl_MemberType.SelectedValue = dtmember.Rows[0]["membertypeid"].ToString();
                        txt_Bank.Text = dtmember.Rows[0]["Bank"].ToString();
                        txt_BankAccount.Text = dtmember.Rows[0]["BankAccount"].ToString();
                        txt_BankNumber.Text = dtmember.Rows[0]["banknumber"].ToString();

                        txt_Password.Text = dtmember.Rows[0]["Password"].ToString();
                        txt_BuyCommodity.Text = dtmember.Rows[0]["BuyCommodity"].ToString();
                        txt_BuyCommodityMonth.Text = dtmember.Rows[0]["BuyCommodityCurrMonth"].ToString();
                        txt_IdentityNumber.Text = dtmember.Rows[0]["IdentityNumber"].ToString();
                        txt_IdentityPic.EmptyText = dtmember.Rows[0]["IdentityPic"].ToString();
                        txt_AgreementPic.EmptyText = dtmember.Rows[0]["AgreementSignedPic"].ToString();
                        
                        txt_TopID.Text = dtmember.Rows[0]["TopMemberID"].ToString();
                        txt_leftID.Text = dtmember.Rows[0]["LeftMemberID"].ToString();
                        txt_InviterID.Text = dtmember.Rows[0]["InviterID"].ToString();
                        if (!string.IsNullOrEmpty(txt_TopID.Text)) {
                            txt_TopMember.Text = GetNameByMemberID(Convert.ToInt32(txt_TopID.Text));
                        }
                        if (!string.IsNullOrEmpty(txt_leftID.Text))
                        {
                            txt_leftMember.Text = GetNameByMemberID(Convert.ToInt32(txt_leftID.Text));
                        }
                        if (!string.IsNullOrEmpty(txt_InviterID.Text))
                        {
                            txt_InviterName.Text = GetNameByMemberID(Convert.ToInt32(txt_InviterID.Text));
                        }
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string IdentityPicName = string.Empty;
            string AgreementPicName = string.Empty;
            if (!string.IsNullOrEmpty(txt_IdentityPic.ShortFileName))
            {
                IdentityPicName = txt_IdentityPic.ShortFileName;
                IdentityPicName = IdentityPicName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                IdentityPicName = DateTime.Now.Ticks.ToString() + "_" + IdentityPicName;
                txt_IdentityPic.SaveAs(Server.MapPath("~/upload/" + IdentityPicName));
                IdentityPicName = Server.MapPath("~/upload/" + IdentityPicName);
            }
            if (!string.IsNullOrEmpty(txt_AgreementPic.ShortFileName))
            {
                AgreementPicName = txt_AgreementPic.ShortFileName;
                AgreementPicName = AgreementPicName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                AgreementPicName = DateTime.Now.Ticks.ToString() + "_" + AgreementPicName;
                txt_AgreementPic.SaveAs(Server.MapPath("~/upload/" + AgreementPicName));
                AgreementPicName = Server.MapPath("~/upload/" + AgreementPicName);
            }

            int? topid = null, inviterid = null, leftid = null;
            if (!string.IsNullOrEmpty(txt_TopID.Text) && txt_TopID.Text!="0")
            {
                topid = Convert.ToInt32(txt_TopID.Text);
            }
            if (!string.IsNullOrEmpty(txt_InviterID.Text) && txt_InviterID.Text != "0")
            {
                inviterid = Convert.ToInt32(txt_InviterID.Text);
            }
            if (!string.IsNullOrEmpty(txt_leftID.Text) && txt_leftID.Text != "0")
            {
                leftid = Convert.ToInt32(txt_leftID.Text);
            }
            if (string.IsNullOrEmpty(txt_memberID.Text.Trim()))
            { //新增
                m_MGMemberBusiness.InsertMember(txt_Name.Text.Trim(), txt_Code.Text.Trim(), txt_CellPhone.Text.Trim(),
                    txt_RealName.Text.Trim(), txt_Mail.Text.Trim(), txt_WeChat.Text.Trim(), Convert.ToInt32(txt_Points.Text==string.Empty?"0":txt_Points.Text),
                    Convert.ToInt32(txt_Credits.Text == string.Empty ? "0" : txt_Credits.Text), txt_Bank.Text.Trim(), txt_BankAccount.Text.Trim(),
                    txt_BankNumber.Text.Trim(), Convert.ToInt32(ddl_Status.SelectedValue), Convert.ToInt32(ddl_MemberType.SelectedValue),
                    txt_Password.Text.Trim(), inviterid, leftid,
                    topid, txt_BuyCommodity.Text.Trim(), txt_BuyCommodityMonth.Text.Trim(), txt_IdentityNumber.Text.Trim(),
                    IdentityPicName, AgreementPicName);
            }
            else { 
                //保存
                m_MGMemberBusiness.UpdateMemberInfoByMemberID(Convert.ToInt32(txt_memberID.Text),
                    txt_Name.Text.Trim(), txt_Code.Text.Trim(), txt_CellPhone.Text.Trim(),
                    txt_RealName.Text.Trim(), txt_Mail.Text.Trim(), txt_WeChat.Text.Trim(), Convert.ToInt32(txt_Points.Text == string.Empty ? "0" : txt_Points.Text),
                    Convert.ToInt32(txt_Credits.Text == string.Empty ? "0" : txt_Credits.Text), txt_Bank.Text.Trim(), txt_BankAccount.Text.Trim(),
                    txt_BankNumber.Text.Trim(), Convert.ToInt32(ddl_Status.SelectedValue), 
                    Convert.ToInt32(ddl_MemberType.SelectedValue),txt_Password.Text.Trim(), inviterid, leftid,
                    topid, txt_BuyCommodity.Text.Trim(), txt_BuyCommodityMonth.Text.Trim(), txt_IdentityNumber.Text.Trim(),
                    IdentityPicName, AgreementPicName);
            }

            PageContext.RegisterStartupScript("parent.__doPostBack('','MemberDetailClose');");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void txt_InviterName_Blur(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_InviterName.Text.Trim()))
                return;

            int memberID = m_MGMemberBusiness.GetMemberIDByName(txt_InviterName.Text.Trim());
            if (memberID == 0)
            {
                txt_InviterID.Text = string.Empty;
                Alert.Show("该用户名不存在", MessageBoxIcon.Warning);
                return;
            }
            txt_InviterID.Text = memberID.ToString();
        }

        protected void txt_leftMember_Blur(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_leftMember.Text.Trim()))
                return;

            int memberID = m_MGMemberBusiness.GetMemberIDByName(txt_leftMember.Text.Trim());
            if (memberID == 0)
            {
                txt_leftID.Text = string.Empty;
                Alert.Show("该用户名不存在", MessageBoxIcon.Warning);
                return;
            }
            txt_leftID.Text = memberID.ToString();
        }

        protected void txt_TopMember_Blur(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_TopMember.Text.Trim()))
                return;

            int memberID = m_MGMemberBusiness.GetMemberIDByName(txt_TopMember.Text.Trim());
            if (memberID == 0)
            {
                txt_TopID.Text = string.Empty;
                Alert.Show("该用户名不存在", MessageBoxIcon.Warning);
                return;
            }
            txt_TopID.Text = memberID.ToString();
        }

        private string GetNameByMemberID(int memberID)
        {
            DataTable dtmember = m_MGMemberBusiness.GetMemberInfoByMemberID(memberID);
            if (dtmember != null && dtmember.Rows.Count > 0) {
                return dtmember.Rows[0]["Name"].ToString();
            }
            return string.Empty;
        }
    }
}