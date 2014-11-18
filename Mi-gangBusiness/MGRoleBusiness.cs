using Mi_gangDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGRoleBusiness
    {
        private MGRoleService m_MGRoleService;

        public MGRoleBusiness()
        {
            m_MGRoleService = new MGRoleService();
        }

        public string GetRoleNameByID(int roleID)
        {
            return m_MGRoleService.GetRoleNameByID(roleID);
        }

        public DataTable GetRoleList(int pageIndex, int pageSize, string roleName)
        {
            return m_MGRoleService.GetRoleList(pageIndex, pageSize, roleName);
        }
        public int GetTotalCount(string roleName)
        {
            return m_MGRoleService.GetTotalCount(roleName);
        }
        public int DeleteRoleByID(int roleID)
        {
            return m_MGRoleService.DeleteRoleByID(roleID);
        }
        public DataTable GetRoleInfoByID(int roleID)
        {
            return m_MGRoleService.GetRoleInfoByID(roleID);
        }
        public int InsertRole(string roleName, string remark,int statusid)
        {
            return m_MGRoleService.InsertRole(roleName, remark, statusid);
        }
        public int UpdateRoleInfoByID(string roleName, string remark, int roleID,int statusID)
        {
            return m_MGRoleService.UpdateRoleInfoByID(roleName, remark, roleID, statusID);
        }
        public int UpdateRoleStatusByID(int statusID, int roleID)
        {
            return m_MGRoleService.UpdateRoleStatusByID(statusID, roleID);
        }

        public DataTable GetStatusInfo()
        {
            return m_MGRoleService.GetStatusInfo();
        }
        public DataTable GetRoleActiveList()
        {
            return m_MGRoleService.GetRoleActiveList();
        }

        public int ManageRoleButton(int buttonid, string[] roles)
        {
            IList<int> roleList = new List<int>();
            for (int i = 0; i < roles.Length; i++)
            {
                roleList.Add(Convert.ToInt32(roles[i]));
            }
            return m_MGRoleService.ManageRoleButton(buttonid, roleList);
        }
        public int ManageRoleUser(int userid, string[] roles)
        {
            IList<int> roleList = new List<int>();
            for (int i = 0; i < roles.Length; i++) {
                roleList.Add(Convert.ToInt32(roles[i]));
            }
            return m_MGRoleService.ManageRoleUser(userid, roleList);
        }
        public DataTable GetButtonRoleByButtonID(int buttonid)
        {
            return m_MGRoleService.GetButtonRoleByButtonID(buttonid);
        }
        public DataTable GetUserRoleByUserID(int userid)
        {
            return m_MGRoleService.GetUserRoleByUserID(userid);
        }
        public DataTable GetRoleInfoByButtonID(int buttonid)
        {
            return m_MGRoleService.GetRoleInfoByButtonID(buttonid);
        }
        public DataTable GetRoleInfoByUserID(int userid) {
            return m_MGRoleService.GetRoleInfoByUserID(userid);
        }
    }
}   
