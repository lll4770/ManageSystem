using Mi_gangDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGLogBusiness
    {
        private LogManageService m_LogManageService;
        public MGLogBusiness()
        {
            m_LogManageService = new LogManageService();
        }

        public DataTable GetSystemLogList(int pageIndex, int pageSize)
        {
            return m_LogManageService.GetSystemLogList(pageIndex, pageSize);
        }
        public int GetSystemLogCount()
        {
            return m_LogManageService.GetSystemLogCount();
        }

        public DataTable GetLogErrorList(int pageIndex, int pageSize)
        {
            return m_LogManageService.GetLogErrorList(pageIndex, pageSize);
        }
        public int GetLogErrorCount()
        {
            return m_LogManageService.GetLogErrorCount();
        }

        public DataTable GetCreditsExChangeLogList(int pageIndex, int pageSize)
        {
            return m_LogManageService.GetCreditsExChangeLogList(pageIndex, pageSize);
        }
        public int GetCreditsExChangeLogCount()
        {
            return m_LogManageService.GetCreditsExChangeLogCount();
        }

        public DataTable GetCreditsChangeLogList(int pageIndex, int pageSize)
        {
            return m_LogManageService.GetCreditsChangeLogList(pageIndex, pageSize);
        }
        public int GetCreditsChangeLogCount()
        {
            return m_LogManageService.GetCreditsChangeLogCount();
        }

        public DataTable GetPointsChangeLogList(int pageIndex, int pageSize)
        {
            return m_LogManageService.GetPointsChangeLogList(pageIndex, pageSize);
        }
        public int GetPointsChangeLogCount()
        {
            return m_LogManageService.GetPointsChangeLogCount();
        }

        public DataTable GetPurchaseLogList(int pageIndex, int pageSize)
        {
            return m_LogManageService.GetPurchaseLogList(pageIndex, pageSize);
        }
        public int GetPurchaseLogCount()
        {
            return m_LogManageService.GetPurchaseLogCount();
        }
    }
}
