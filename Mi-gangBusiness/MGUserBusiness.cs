using Mi_gangDataService;
using Mi_gangEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGUserBusiness
    {
        private MGUserService m_MGUserService;

        public MGUserBusiness()
        {
            m_MGUserService = new MGUserService();
        }

        public DataTable GetUserList(int pageIndex, int pageSize,string usernumber,string code,string name)
        {
            return m_MGUserService.GetUserList(pageIndex, pageSize, usernumber,code,name);
        }

        public int GetUserCount(string usernumber, string code, string name)
        {
            return m_MGUserService.GetUserCount(usernumber, code, name);
        }
        public DataTable GetUserInfoByID(int userid)
        {
            return m_MGUserService.GetUserInfoByID(userid);
        }
        public int InsertUser(string userNumber, string name, string code, string nickName,
            string creatDate, int statusID, string remark)
        {
            DateTime ctime = Convert.ToDateTime(creatDate);
            return m_MGUserService.InsertUser(userNumber, name, code, nickName, ctime, statusID, remark);
        }
        public int UpdateUserByID(string userNumber, string name, string code, string nickName,
            string creatDate, int statusID, string remark, int userid) {
                DateTime ctime = Convert.ToDateTime(creatDate);
                return m_MGUserService.UpdateUserByID(userNumber, name, code, nickName, ctime, statusID, remark, userid);
        }
        public int UpdateUserPasswordByUserid(int userid, string password)
        {
            return m_MGUserService.UpdateUserPasswordByUserid(userid, password);
        }
        public int DelUserByUserID(int userID)
        {
            return m_MGUserService.DelUserByUserID(userID);
        }
        public UserInfo UserLogin(string userNumber, string password)
        {
            return m_MGUserService.UserLogin(userNumber, password);
        }
    }
}
