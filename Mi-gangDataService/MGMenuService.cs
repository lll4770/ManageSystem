using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public class MGMenuService
    {
        public DataTable GetMenuList(int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = pageSize * (pageIndex+1);
            string sql = string.Format(MGSqlList.Sql_GetMenuList,start,end);
            return DBHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 获取菜单总条数
        /// </summary>
        /// <returns></returns>
        public int GetMenuCount()
        {
            string sql = MGSqlList.Sql_GetMenuCount;
            object result = DBHelper.ExecuteScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public DataTable GetParentMenu()
        {
            string sql = MGSqlList.Sql_GetParentInfo;
            return DBHelper.GetDataTable(sql);
        }

        public DataTable GetMenuInfoByMenuID(int memuID)
        {
            string sql = string.Format(MGSqlList.Sql_GetMenuInfoByMenuId, memuID);
            return DBHelper.GetDataTable(sql);
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
        public int InsertMenu(string menuName,int orderID,int parentID,string menuUrl,int valid)
        {
            string sql = string.Empty;
            if (parentID == -1)
            {
                sql = string.Format(MGSqlList.Sql_InsertMenuEx, menuName, orderID, menuUrl, valid);
            }
            else
            {
                sql = string.Format(MGSqlList.Sql_InsertMenu, menuName, orderID, parentID, menuUrl, valid);
            }
            return DBHelper.ExecuteNonQuery(sql);
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
        public int UpdateMenuByMenuID(int menuID,string menuName, int orderID, int parentID, string menuUrl, int valid)
        {
            string sql = string.Empty;
            if (parentID == -1)
            {
                sql = string.Format(MGSqlList.Sql_UpdateMenuByIDEx, menuName, orderID, menuUrl, valid, menuID);
                
            }
            else
            {
                sql = string.Format(MGSqlList.Sql_UpdateMenuByID, menuName, orderID, parentID, menuUrl, valid, menuID);
            }
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int DelMenuByMenuID(int menuID)
        {
            string sql = string.Empty;
            using (Trans t = new Trans()) {
                try {
                    sql = string.Format(MGSqlList.Sql_DelButtonByMenuID, menuID);
                    DBHelper.ExecuteNonQuery(sql, t);
                    sql = string.Format(MGSqlList.Sql_DelMenuByID, menuID);
                    DBHelper.ExecuteNonQuery(sql, t);
                    return 1;
                }
                catch {
                    t.RollBack();
                    return 0;
                }
                finally {
                    t.Commit();
                }
            }
        }

        public DataTable GetMenuInfo()
        {
            string sql = string.Format(MGSqlList.Sql_GetMenuInfo);
            return DBHelper.GetDataTable(sql);
        }

        public DataTable GetMenuInfoByRoleID(int roleID)
        {
            string sql = string.Format(MGSqlList.Sql_GetMenuByRoleID, roleID);
            return DBHelper.GetDataTable(sql);
        }
        

        public DataTable GetMenuInfoByRoleIDs(string roleIDs)
        {
            string sql = string.Format(MGSqlList.Sql_GetMenuByRoleIDs, roleIDs);
            return DBHelper.GetDataTable(sql);
        }

        public bool UpdateMenuByRoleID(int roleID, IList<string> menuIDaddList, IList<string> menuIDdelList)
        {
            string sql = string.Empty;
            using (Trans t = new Trans()) {
                try
                {
                    if (menuIDdelList != null && menuIDdelList.Count > 0)
                    {
                        foreach (var item in menuIDdelList)
                        {
                            sql = string.Format(MGSqlList.Sql_DelMenu2Role, roleID, Convert.ToInt32(item));
                            DBHelper.ExecuteNonQuery(sql, t);
                        }
                    }
                    if (menuIDaddList != null && menuIDaddList.Count > 0)
                    {
                        foreach (var item in menuIDaddList)
                        {
                            sql = string.Format(MGSqlList.Sql_InsertMenu2Role, Convert.ToInt32(item), roleID);
                            DBHelper.ExecuteNonQuery(sql, t);
                        }
                    }
                    return true;
                }
                catch
                {
                    t.RollBack();
                    return false;
                }
                finally {
                    t.Commit();
                }
            }
            
        }
    }
}
