using Mi_gangDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGAnnouncementBusiness
    {
        private MGAnnouncementService m_MGAnnouncementService;

        public MGAnnouncementBusiness()
        {
            m_MGAnnouncementService = new MGAnnouncementService();
        }

        public DataTable GetAnnouncementList(int pageIndex, int pageSize,int typeid,string name,string starttime)
        {
            return m_MGAnnouncementService.GetAnnouncementList(pageIndex, pageSize,typeid,name,starttime);
        }

        public int GetAnnouncementCount(int typeid, string name, string starttime)
        {
            return m_MGAnnouncementService.GetAnnouncementCount(typeid, name, starttime);
        }

        public int DelAnnoncementByID(int announcementid)
        {
            return m_MGAnnouncementService.DelAnnoncementByID(announcementid);
        }

        public DataTable GetAnnouncementByID(int id)
        {
            return m_MGAnnouncementService.GetAnnouncementByID(id);
        }

        public DataTable GetAnnouncementType()
        {
            return m_MGAnnouncementService.GetAnnouncementType();
        }

        public int UpdateAnnouncementByID(string content, int memberid, int typeid, DateTime start,
            DateTime end, int id)
        {
            return m_MGAnnouncementService.UpdateAnnouncementByID(content, memberid, typeid, start, end, id);
        }

        public int InsertAnnouncement(string content, int memberid, int typeid, DateTime start, DateTime end)
        {
            return m_MGAnnouncementService.InsertAnnouncement(content, memberid, typeid, start, end);
        }
    }
}
