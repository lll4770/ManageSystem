using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class MGAnnouncementService
    {
        public DataTable GetAnnouncementList(int pageIndex, int pageSize,int typeid,string name,string starttime)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex + 1);
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                sqlAppend += string.Format(" and member.Name like '%{0}%'", name);
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                sqlAppend += string.Format(" and ValidDateFrom>'{0}'", starttime);
            }
            if (typeid>0)
            {
                sqlAppend += string.Format(" and announcement.[AnnouncementTypeID] ={0}", typeid);
            }
            string sql = string.Format(MGSqlList.Sql_GetAnnoncementList, start, end, sqlAppend);
            return DBHelper.GetDataTable(sql);
        }

        public int GetAnnouncementCount(int typeid, string name, string starttime)
        {
            string sqlAppend = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                sqlAppend += string.Format(" and member.Name like '%{0}%'", name);
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                sqlAppend += string.Format(" and ValidDateFrom>'{0}'", starttime);
            }
            if (typeid > 0)
            {
                sqlAppend += string.Format(" and announcement.[AnnouncementTypeID] ={0}", typeid);
            }
            string sql = string.Format(MGSqlList.Sql_GetAnnoncementCount, sqlAppend);
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public int DelAnnoncementByID(int announcementid)
        {
            return DBHelper.ExecuteNonQuery(string.Format(MGSqlList.Sql_DelAnnoucementByID, announcementid));
        }

        public DataTable GetAnnouncementByID(int id) {
            return DBHelper.GetDataTable(string.Format(MGSqlList.Sql_GetAnnoucementByID, id));
        }

        public DataTable GetAnnouncementType()
        {
            return DBHelper.GetDataTable(MGSqlList.Sql_GetAnnoucementType);
        }

        public int InsertAnnouncement(string content,int memberid,int typeid,DateTime start,DateTime end)
        {
            string sql = string.Format(MGSqlList.Sql_InsertAnnouncement, typeid, memberid, start, end, content);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int UpdateAnnouncementByID(string content, int memberid, int typeid, DateTime start, 
            DateTime end,int id)
        {
            string sql = string.Format(MGSqlList.Sql_UpdateAnnouncementByID, typeid, memberid, start, end, content, id);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
