using Mi_gangDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGButtonBusiness
    {
        private MGButtonService m_MGButtonService;
        public MGButtonBusiness()
        {
            m_MGButtonService = new MGButtonService();
        }

        public DataTable GetButtonList(int pageIndex, int pageSize,string buttonName)
        {
            return m_MGButtonService.GetButtonList(pageIndex, pageSize, buttonName);
        }

        /// <summary>
        /// 获取按钮总条数
        /// </summary>
        /// <returns></returns>
        public int GetButtonCount(string buttonName)
        {
            return m_MGButtonService.GetButtonCount(buttonName);
        }

        public int DelButtonByID(int buttonID)
        {
            return m_MGButtonService.DelButtonByID(buttonID);
        }

        public DataTable GetButtonInfoByID(int buttonID) {
            return m_MGButtonService.GetButtonInfoByID(buttonID);
        }

        public int InsertButton(int menuID, string buttonName, int IsAuthority)
        {
            return m_MGButtonService.InsertButton(menuID, buttonName, IsAuthority);
        }

        public int UpdateButtonInfoByID(int buttonID, int menuID, string buttonName, int IsAuthority)
        {
            return m_MGButtonService.UpdateButtonInfoByID(buttonID, menuID, buttonName, IsAuthority);
        }
    }
}
