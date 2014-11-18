using Common;
using Helper;
using Mi_gangEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class MGUserService
    {
        public DataTable GetUserList(int pageIndex, int pageSize,string usernumber,string code,string name)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(usernumber))
            {
                sqlAppend += string.Format(" and UserNumber like '%{0}%'", usernumber);
            }
            if (!string.IsNullOrEmpty(code)) {
                sqlAppend += string.Format(" and code like '%{0}%'", code);
            }
            if (!string.IsNullOrEmpty(name))
            {
                sqlAppend += string.Format(" and name like '%{0}%'", name);
            }
            string sql = string.Format(MGSqlList.Sql_GetUserList, start, end, sqlAppend);
            return DBHelper.GetDataTable(sql);
        }

        public int GetUserCount(string usernumber,string code,string name)
        {
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(usernumber))
            {
                sqlAppend += string.Format(" and UserNumber like '%{0}%'", usernumber);
            }
            if (!string.IsNullOrEmpty(code))
            {
                sqlAppend += string.Format(" and code like '%{0}%'", code);
            }
            if (!string.IsNullOrEmpty(name))
            {
                sqlAppend += string.Format(" and name like '%{0}%'", name);
            }
            string sql = string.Format(MGSqlList.Sql_GetUserCount, sqlAppend);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public DataTable GetUserInfoByID(int userid)
        {
            string sql = string.Format(MGSqlList.Sql_GetUserInfoByID, userid);
            return DBHelper.GetDataTable(sql);
        }

        public int InsertUser(string userNumber, string name, string code, string nickName,
            DateTime creatDate, int statusID, string remark)
        {
            string sql = string.Format(MGSqlList.Sql_InsertUser, userNumber, name, code, nickName, creatDate,
                statusID, remark);
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int UpdateUserByID(string userNumber, string name, string code, string nickName,
            DateTime creatDate, int statusID, string remark, int userid)
        {
            string sql = string.Format(MGSqlList.Sql_UpdateUserByID,userid, userNumber, name, code, nickName, creatDate,
                statusID, remark);
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int UpdateUserPasswordByUserid(int userid,string password)
        {
            string sql = string.Format(MGSqlList.Sql_UpdatePassword, password, userid);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int DelUserByUserID(int userID)
        {
            string sql = string.Empty;
            using (Trans t = new Trans())
            {
                try
                {
                    sql = string.Format(MGSqlList.Sql_DelUserRoleByUserId, userID);
                    DBHelper.ExecuteNonQuery(sql, t);
                    sql = string.Format(MGSqlList.Sql_DeleteUserByID, userID);
                    DBHelper.ExecuteNonQuery(sql, t);
                    return 1;
                }
                catch
                {
                    t.RollBack();
                    return 0;
                }
                finally
                {
                    t.Commit();
                }
            }
        }

        public UserInfo UserLogin(string userNumber, string password)
        {
            string sql = string.Format(MGSqlList.Sql_UserLogIn, userNumber, password);
            //return DBHelper.GetDataTable(sql);
            DataTable dt = DBHelper.GetDataTable(sql);
            IList<UserInfo> userList = Object2Data.ConvertTo<UserInfo>(dt);
            if (userList != null && userList.Count > 0)
                return userList[0];
            return null;
        }
    }
}
