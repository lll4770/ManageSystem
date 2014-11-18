using Mi_gangDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangBusiness
{
    public class MGMenuBusiness
    {
        private MGMenuService m_MenuService;

        public MGMenuBusiness()
        {
            m_MenuService = new MGMenuService();
        }

        public DataTable GetMenuList(int pageIndex, int pageSize)
        {
            return m_MenuService.GetMenuList(pageIndex, pageSize);
        }

        /// <summary>
        /// 获取菜单总条数
        /// </summary>
        /// <returns></returns>
        public int GetMenuCount()
        {
            return m_MenuService.GetMenuCount();
            //return totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1);
        }

        public DataTable GetParentMenu()
        {
            return m_MenuService.GetParentMenu();
        }

        public DataTable GetMenuInfoByMenuID(int memuID)
        {
            return m_MenuService.GetMenuInfoByMenuID(memuID);
        }

        /// <summary>
        /// 菜单新增
        /// </summary>
        /// <param name="menuName"></param>
        /// <param name="orderID"></param>
        /// <param name="parentID"></param>
        /// <param name="menuUrl"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        public int InsertMenu(string menuName, int orderID, int parentID, string menuUrl, int valid)
        {
            return m_MenuService.InsertMenu(menuName, orderID, parentID, menuUrl, valid);
        }

        /// <summary>
        /// 根据菜单id修改菜单
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="menuName"></param>
        /// <param name="orderID"></param>
        /// <param name="parentID"></param>
        /// <param name="menuUrl"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        public int UpdateMenuByMenuID(int menuID, string menuName, int orderID, int parentID, string menuUrl, int valid)
        {
            return m_MenuService.UpdateMenuByMenuID(menuID, menuName, orderID, parentID, menuUrl, valid);
        }

        public int DelMenuByMenuID(int menuID)
        {
            return m_MenuService.DelMenuByMenuID(menuID);
        }

        public DataTable GetMenuInfo()
        {
            return m_MenuService.GetMenuInfo();
        }

        public DataTable GetMenuInfoByRoleID(int roleID)
        {
            return m_MenuService.GetMenuInfoByRoleID(roleID);
        }

        public DataTable GetMenuInfoByRoleIDs(string roleIDs)
        {
            return m_MenuService.GetMenuInfoByRoleIDs(roleIDs);
        }

        public bool UpdateMenuInfoByRoleID(int roleID, IList<string> menuList)
        {
            IList<string> menuIDaddList = new List<string>();//待添加的菜单
            IList<string> menuIDdelList = new List<string>();//待删除的菜单

            DataTable dtExists = GetMenuInfoByRoleID(roleID);//数据库中已存在的菜单信息
            IList<string> menuExistList = new List<string>();
            if (null != dtExists && dtExists.Rows.Count > 0)
            {
                for (int j = 0; j < dtExists.Rows.Count; j++)
                {
                    menuExistList.Add(dtExists.Rows[j]["menuID"].ToString());
                }
            }



            return m_MenuService.UpdateMenuByRoleID(roleID, menuList, menuExistList);
        }
    }
}
