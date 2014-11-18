using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class MGMemberService
    {
        public DataTable GetMemberList(int pageIndex, int pageSize, string userName, string code, string realName)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(userName))
            {
                sqlAppend += string.Format(" and Name like '%{0}%'", userName);
            }
            if (!string.IsNullOrEmpty(code))
            {
                sqlAppend += string.Format(" and code like '%{0}%'", code);
            }
            if (!string.IsNullOrEmpty(realName))
            {
                sqlAppend += string.Format(" and Realname like '%{0}%'", realName);
            }
            string sql = string.Format(MGSqlList.Sql_GetMemberList, start, end, sqlAppend);
            return DBHelper.GetDataTable(sql);
        }

        public int GetMemberCount(string userName, string code, string realName)
        {
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(userName))
            {
                sqlAppend += string.Format(" and Name like '%{0}%'", userName);
            }
            if (!string.IsNullOrEmpty(code))
            {
                sqlAppend += string.Format(" and code like '%{0}%'", code);
            }
            if (!string.IsNullOrEmpty(realName))
            {
                sqlAppend += string.Format(" and Realname like '%{0}%'", realName);
            }
            string sql = string.Format(MGSqlList.Sql_GetMemberCount, sqlAppend);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public DataTable GetMemberTypeInfo() {
            return DBHelper.GetDataTable(MGSqlList.Sql_GetMemberType);
        }

        public DataTable GetMemberInfoByMemberID(int memberid)
        {
            string sql = string.Format(MGSqlList.Sql_GetMemberByMemberID, memberid);
            return DBHelper.GetDataTable(sql);
        }

        public int UpdateMemberInfoByMemberID(int memberid,string name,string code,string cellphone,
            string realName,string mail,string weichat,int points,int credits,string bank,string bankAccount,
            string bankNumber, int statusid, int membertypeid, string password, int? InviterID, int? LeftMemberID, int? TopMemberID,
            string BuyCommodity, string BuyCommodityCurrMonth, string IdentityNumber, string IdentityPic, string AgreementSignedPic)
        {
            string sql = string.Empty;
            string valueAppend = string.Empty;
            if (InviterID != null)
            {
                valueAppend += string.Format(",InviterID={0}",InviterID);
            }
            if (LeftMemberID != null)
            {
                valueAppend += string.Format(",LeftMemberID={0}", LeftMemberID);
            }
            if (TopMemberID != null)
            {
                valueAppend += string.Format(",TopMemberID={0}", TopMemberID);
            }
            sql = string.Format(MGSqlList.Sql_UpdateMemberByMemberID, name, code, cellphone, realName, mail, weichat,
                points, credits, bank, bankAccount, bankNumber, memberid, statusid, membertypeid,
                BuyCommodity, BuyCommodityCurrMonth, IdentityNumber, IdentityPic, AgreementSignedPic, password,valueAppend);
            return DBHelper.ExecuteNonQuery(sql); 
        }

        public int InsertMember( string name, string code, string cellphone,
            string realName, string mail, string weichat, int points, int credits, string bank, string bankAccount,
            string bankNumber, int statusid, int membertypeid, string password, int? InviterID, int? LeftMemberID, int? TopMemberID,
            string BuyCommodity, string BuyCommodityCurrMonth, string IdentityNumber, string IdentityPic, string AgreementSignedPic)
        {
            string sql = string.Empty;
            string columnAppend = string.Empty;
            string valuesAppend = string.Empty;
            if (InviterID != null) {
                columnAppend += ",InviterID";
                valuesAppend += "," + InviterID;
            }
            if (LeftMemberID != null) {
                columnAppend += ",LeftMemberID";
                valuesAppend += "," + LeftMemberID;
            }
            if (TopMemberID != null) {
                columnAppend += ",TopMemberID";
                valuesAppend += "," + TopMemberID;
            }
            sql = string.Format(MGSqlList.Sql_InsertMember, name, code, cellphone, realName, mail, weichat,
                points, credits, bank, bankAccount, bankNumber, statusid, membertypeid, password,
                BuyCommodity, BuyCommodityCurrMonth, IdentityNumber, IdentityPic, AgreementSignedPic, columnAppend, valuesAppend);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int DeleteMemberByMemberID(int memberID)
        {
            string sql = string.Format(MGSqlList.Sql_DeleteMemberByID, memberID);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public DataTable GetMemberGradeList(int pageIndex, int pageSize) {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sql = string.Format(MGSqlList.Sql_GetMemberGradeList, start, end);
            return DBHelper.GetDataTable(sql);
        }

        public int GetMemberGradeCount()
        {
            object result = DBHelper.ExecuteScalar(MGSqlList.Sql_GetMemberGradeCount);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public DataTable GetMemberGradeByID(int gradeID)
        {
            string sql = string.Format(MGSqlList.Sql_GetMemberGradeID, gradeID);
            return DBHelper.GetDataTable(sql);
        }

        public int DelMemberGradeByID(int gradeID) {
            string sql = string.Format(MGSqlList.Sql_DelMemberGradeByID, gradeID);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int UpdateMemberGradeByID(int id, string grade, int points, int orderid) {
            string sql = string.Format(MGSqlList.Sql_UpdateMemberByID, grade, points, orderid, id);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int InsertMemberGrade(string grade, int points, int orderid) {
            string sql = string.Format(MGSqlList.Sql_InsertMemberGrade, grade, points, orderid);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int GetMemberIDByName(string name)
        {
            string sql = string.Format(MGSqlList.Sql_GetmemberIDByMemberName, name);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public DataTable GetMemberAddressByMemberID(int memberid)
        {
            string sql = string.Format(MGSqlList.Sql_GetMemberLocationByMemberid, memberid);
            return DBHelper.GetDataTable(sql);
        }
        public int GetMemberLocationCount(int memberid)
        {
            string sql = string.Format(MGSqlList.Sql_GetMemberLocationCount, memberid);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

    }
}   
