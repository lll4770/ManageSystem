using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class MGButtonService
    {
        public DataTable GetButtonList(int pageIndex, int pageSize,string buttonName)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(buttonName)) {
                sqlAppend += string.Format("and button.Name like '%{0}%'",buttonName);
            }
            string sql = string.Format(MGSqlList.Sql_GetButtonList, start, end, sqlAppend);
            return DBHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 获取按钮总条数
        /// </summary>
        /// <returns></returns>
        public int GetButtonCount(string buttonName)
        {
            string sqlAppend = string.Empty; 
            if (!string.IsNullOrEmpty(buttonName))
            {
                sqlAppend += string.Format("and Name like '%{0}%'", buttonName);
            }
            string sql = string.Format(MGSqlList.Sql_GetButtonCount, sqlAppend);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public int DelButtonByID(int buttonID)
        {
            string sql = string.Empty;
            using (Trans t = new Trans())
            {
                try
                {
                    sql = string.Format(MGSqlList.Sql_DelButtonRoleByButtonID, buttonID);
                    DBHelper.ExecuteNonQuery(sql, t);
                    sql = string.Format(MGSqlList.Sql_DelButtonByID, buttonID);
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

        public DataTable GetButtonInfoByID(int buttonID)
        {
            string sql = string.Format(MGSqlList.Sql_GetButtonInfoByID, buttonID);
            return DBHelper.GetDataTable(sql);
        }

        public int InsertButton(int menuID, string buttonName, int IsAuthority)
        {
            string sql = string.Format(MGSqlList.Sql_InsertButton,menuID,buttonName,IsAuthority);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int UpdateButtonInfoByID(int buttonID, int menuID, string buttonName, int IsAuthority)
        {
            string sql = string.Format(MGSqlList.Sql_UpdateButtonByID, menuID, buttonName, IsAuthority, buttonID);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
