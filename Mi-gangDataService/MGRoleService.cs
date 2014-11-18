using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class MGRoleService
    {
        public string GetRoleNameByID(int roleID)
        {
            string sql = string.Format(MGSqlList.Sql_GetRoleNameByID, roleID);
            return DBHelper.ExecuteScalar(sql).ToString();
        }

        public DataTable GetRoleList(int pageIndex, int pageSize, string roleName)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(roleName))
            {
                sqlAppend += string.Format(" and Name like '%{0}%'", roleName);
            }
            string sql = string.Format(MGSqlList.Sql_GetRoleList, start, end, sqlAppend);
            return DBHelper.GetDataTable(sql);
        }

        public int GetTotalCount(string roleName)
        {
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(roleName))
            {
                sqlAppend += string.Format(" and Name like '%{0}%'", roleName);
            }
            string sql = string.Format(MGSqlList.Sql_GetRoleCount, sqlAppend);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }
        public int DeleteRoleByID(int roleID)
        {
            string sql = string.Format(MGSqlList.Sql_DeleteRoleByID, roleID);
            return DBHelper.ExecuteNonQuery(sql);
        }
        public DataTable GetRoleInfoByID(int roleID)
        {
            string sql = string.Format(MGSqlList.Sql_GetRoleInfoByID, roleID);
            return DBHelper.GetDataTable(sql);
        }
        public int InsertRole(string roleName, string remark, int statusid)
        {
            string sql = string.Format(MGSqlList.Sql_InsertRole, roleName, remark, statusid);
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int UpdateRoleInfoByID(string roleName, string remark, int roleID, int statusid)
        {
            string sql = string.Format(MGSqlList.Sql_UpdateRoleByID, roleName, remark, roleID, statusid);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int UpdateRoleStatusByID(int statusID, int roleID)
        {
            string sql = string.Format(MGSqlList.Sql_UpdateRoleStatus, statusID, roleID);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public DataTable GetStatusInfo()
        {
            string sql = MGSqlList.Sql_GetAllRoleInfo;
            return DBHelper.GetDataTable(sql);
        }
        public DataTable GetRoleActiveList()
        {
            string sql = MGSqlList.Sql_GetRoleListActive;
            return DBHelper.GetDataTable(sql);
        }

        public int ManageRoleButton(int buttonid, IList<int> rolelist)
        {
            string sql = string.Empty;
            using (Trans t = new Trans())
            {
                try
                {
                    sql = string.Format(MGSqlList.Sql_DelRoleButton, buttonid);
                    DBHelper.ExecuteNonQuery(sql, t);
                    foreach (var role in rolelist)
                    {
                        sql = string.Format(MGSqlList.Sql_InsertRoleButton, buttonid, role);
                        DBHelper.ExecuteNonQuery(sql, t);
                    }
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

        public int ManageRoleUser(int userid, IList<int> rolelist)
        {
            string sql = string.Empty;
            using (Trans t = new Trans())
            {
                try
                {
                    sql = string.Format(MGSqlList.Sql_DelRoleUser, userid);
                    DBHelper.ExecuteNonQuery(sql, t);
                    foreach (var role in rolelist)
                    {
                        sql = string.Format(MGSqlList.Sql_InsertRoleUser, userid, role);
                        DBHelper.ExecuteNonQuery(sql, t);
                    }
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

        public DataTable GetButtonRoleByButtonID(int buttonid)
        {
            string sql = string.Format(MGSqlList.Sql_GetRoleButtonByButtonID, buttonid);
            return DBHelper.GetDataTable(sql);
        }
        public DataTable GetUserRoleByUserID(int userid)
        {
            string sql = string.Format(MGSqlList.SqlGetRoleUserByUserID, userid);
            return DBHelper.GetDataTable(sql);
        }

        public DataTable GetRoleInfoByButtonID(int buttonid)
        {
            string sql = string.Format(MGSqlList.Sql_GetRoleInfoByButtonID, buttonid);
            return DBHelper.GetDataTable(sql);
        }
        public DataTable GetRoleInfoByUserID(int userid)
        {
            string sql = string.Format(MGSqlList.Sql_GetRoleInfoByUserID, userid);
            return DBHelper.GetDataTable(sql);
        }
    }
}
