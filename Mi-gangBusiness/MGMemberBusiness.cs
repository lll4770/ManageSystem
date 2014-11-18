using Mi_gangDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGMemberBusiness
    {
        private MGMemberService m_MGMemberService;
        public MGMemberBusiness()
        {
            m_MGMemberService = new MGMemberService();
        }

        public DataTable GetMemberList(int pageIndex, int pageSize, string userName,
            string code, string realName)
        {
            return m_MGMemberService.GetMemberList(pageIndex, pageSize, userName, code, realName);
        }

        public int GetMemberCount(string userName, string code, string realName)
        {
            return m_MGMemberService.GetMemberCount(userName, code, realName);
        }

        public DataTable GetMemberTypeInfo()
        {
            return m_MGMemberService.GetMemberTypeInfo();
        }

        public DataTable GetMemberInfoByMemberID(int memberid)
        {
            return m_MGMemberService.GetMemberInfoByMemberID(memberid);
        }

        public int UpdateMemberInfoByMemberID(int memberid, string name, string code, string cellphone,
            string realName, string mail, string weichat, int points, int credits, string bank, string bankAccount,
            string bankNumber, int statusid, int membertypeid, string password, int? InviterID, int? LeftMemberID, int? TopMemberID,
            string BuyCommodity, string BuyCommodityCurrMonth, string IdentityNumber, string IdentityPic, string AgreementSignedPic)
        {
            return m_MGMemberService.UpdateMemberInfoByMemberID(memberid, name, code, cellphone, realName, mail,
                weichat, points, credits, bank, bankAccount, bankNumber, statusid, membertypeid,password,InviterID,LeftMemberID,
                TopMemberID,BuyCommodity,BuyCommodityCurrMonth,IdentityNumber,IdentityPic,AgreementSignedPic);
        }

        public int InsertMember(string name, string code, string cellphone,
            string realName, string mail, string weichat, int points, int credits, string bank, string bankAccount,
            string bankNumber, int statusid, int membertypeid, string password, int? InviterID, int? LeftMemberID, int? TopMemberID,
            string BuyCommodity, string BuyCommodityCurrMonth, string IdentityNumber, string IdentityPic, string AgreementSignedPic)
        {
            return m_MGMemberService.InsertMember(name, code, cellphone, realName, mail, weichat, points,
                credits, bank, bankAccount, bankNumber, statusid, membertypeid, password, InviterID, LeftMemberID, TopMemberID,
                BuyCommodity, BuyCommodityCurrMonth, IdentityNumber, IdentityPic, AgreementSignedPic);
        }

        public int DeleteMemberByMemberID(int memberID)
        {
            return m_MGMemberService.DeleteMemberByMemberID(memberID);
        }

        public DataTable GetMemberGradeList(int pageIndex, int pageSize)
        {
            return m_MGMemberService.GetMemberGradeList(pageIndex, pageSize);
        }

        public int GetMemberGradeCount()
        {
            return m_MGMemberService.GetMemberGradeCount();
        }

        public DataTable GetMemberGradeByID(int gradeID)
        {
            return m_MGMemberService.GetMemberGradeByID(gradeID);
        }
        public int DelMemberGradeByID(int gradeID)
        {
            return m_MGMemberService.DelMemberGradeByID(gradeID);
        }

        public int UpdateMemberGradeByID(int id, string grade, int points, int orderid)
        {
            return m_MGMemberService.UpdateMemberGradeByID(id, grade, points, orderid);
        }

        public int InsertMemberGrade(string grade, int points, int orderid) {
            return m_MGMemberService.InsertMemberGrade(grade, points, orderid);
        }

        public int GetMemberIDByName(string name)
        {
            return m_MGMemberService.GetMemberIDByName(name);
        }

        public DataTable GetMemberAddressByMemberID(int memberid)
        {
            return m_MGMemberService.GetMemberAddressByMemberID(memberid);
        }
        public int GetMemberLocationCount(int memberid)
        {
            return m_MGMemberService.GetMemberLocationCount(memberid);
        }
    }
}
