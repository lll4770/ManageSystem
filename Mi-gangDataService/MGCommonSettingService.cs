using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class MGCommonSettingService
    {
        public DataTable GetCommonSettingList(int pageIndex,int pageSize,string name)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                sqlAppend += string.Format(" and Name like '%{0}%'", name);
            }
            string sql = string.Format(MGSqlList.Sql_GetCommonSettingsList, start, end, sqlAppend);
            return DBHelper.GetDataTable(sql);
        }

        public int GetCommonSettingCount(string name)
        {
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                sqlAppend += string.Format(" and Name like '%{0}%'", name);
            }
            string sql = string.Format(MGSqlList.Sql_GetCommonSettingsCount, sqlAppend);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public int DeleteCommonSettingsByID(int ID)
        {
            string sql = string.Format(MGSqlList.Sql_DeleteCommSettingsByID, ID);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public DataTable GetCommonSettinsByID(int ID)
        {
            string sql = string.Format(MGSqlList.Sql_GetCommonSettingsByID, ID);
            return DBHelper.GetDataTable(sql);
        }

        public int InsertCommonSetting(string name, string value)
        {
            string sql = string.Format(MGSqlList.Sql_InsertCommonSetting, name, value);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int UpdateCommonSettingByID(string name, string value, int id)
        {
            string sql = string.Format(MGSqlList.Sql_UpdateCommonSettingByID, name, value, id);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
