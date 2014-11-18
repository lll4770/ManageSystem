using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class LogManageService
    {
        public DataTable GetSystemLogList(int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sql = string.Format(MGSqlList.Sql_GetSystemLogList, start, end);
            return DBHelper.GetDataTable(sql);
        }
        public int GetSystemLogCount()
        {
            return DBHelper.ExecuteNonQuery(MGSqlList.Sql_GetSystemLogCount);
        }

        public DataTable GetLogErrorList(int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sql = string.Format(MGSqlList.Sql_GetErrorLogList, start, end);
            return DBHelper.GetDataTable(sql);
        }
        public int GetLogErrorCount()
        {
            return DBHelper.ExecuteNonQuery(MGSqlList.Sql_GetErrorLogCount);
        }

        public DataTable GetCreditsExChangeLogList(int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sql = string.Format(MGSqlList.Sql_GetCreditsExChangeLogList, start, end);
            return DBHelper.GetDataTable(sql);
        }
        public int GetCreditsExChangeLogCount()
        {
            return DBHelper.ExecuteNonQuery(MGSqlList.Sql_GetGetCreditsExChangeLogCount);
        }

        public DataTable GetCreditsChangeLogList(int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sql = string.Format(MGSqlList.Sql_GetCreditsChangeList, start, end);
            return DBHelper.GetDataTable(sql);
        }
        public int GetCreditsChangeLogCount()
        {
            return DBHelper.ExecuteNonQuery(MGSqlList.Sql_GetCreditsChangeCount);
        }

        public DataTable GetPointsChangeLogList(int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sql = string.Format(MGSqlList.Sql_GetPointsChangeList, start, end);
            return DBHelper.GetDataTable(sql);
        }
        public int GetPointsChangeLogCount()
        {
            return DBHelper.ExecuteNonQuery(MGSqlList.Sql_GetPointsChangeCount);
        }

        public DataTable GetPurchaseLogList(int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sql = string.Format(MGSqlList.Sql_GetPurchaseLogList, start, end);
            return DBHelper.GetDataTable(sql);
        }
        public int GetPurchaseLogCount()
        {
            return DBHelper.ExecuteNonQuery(MGSqlList.Sql_GetPurchaseLogCount);
        }
    }
}
