using Mi_gangDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGCommonSettingBusiness
    {
        private MGCommonSettingService m_MGCommonSettingService;
        public MGCommonSettingBusiness()
        {
            m_MGCommonSettingService = new MGCommonSettingService();
        }
        public DataTable GetCommonSettingList(int pageIndex, int pageSize, string name)
        {
            return m_MGCommonSettingService.GetCommonSettingList(pageIndex, pageSize, name);
        }

        public int GetCommonSettingCount(string name)
        {
            return m_MGCommonSettingService.GetCommonSettingCount(name);
        }

        public int DeleteCommonSettingsByID(int ID)
        {
            return m_MGCommonSettingService.DeleteCommonSettingsByID(ID);
        }
        public DataTable GetCommonSettinsByID(int ID)
        {
            return m_MGCommonSettingService.GetCommonSettinsByID(ID);
        }
        public int InsertCommonSetting(string name, string value)
        {
            return m_MGCommonSettingService.InsertCommonSetting(name, value);
        }
        public int UpdateCommonSettingByID(string name, string value, int id)
        {
            return m_MGCommonSettingService.UpdateCommonSettingByID(name, value, id);
        }
    }
}
