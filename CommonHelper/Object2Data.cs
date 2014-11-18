/***********************************************************
 ** File Name : Object2Data.cs
 ** Copyright (C) 2012 BenQ Corporation. All rights reserved.
 **
 ** Creator : DS22/Klaus.You
 ** Create Date : 2012-07-24
 ** Modifier :
 ** Modify Date :
 **
 ** Description:实现数据到实体的映射功能
 **
 ** Edit Date：2012-07-25 Klaus.You
 ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    public class Object2Data
    {
        private Object2Data()
        {

        }

        #region List2DataTable

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }
        #endregion


        #region Rows2List
        /// <summary>
        /// Rows2List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }
        #endregion

        #region Talbe2List
        /// <summary>
        /// Table2List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }
        #endregion

        #region Row2Object
        public static T CreateItem<T>(DataRow row)
        {
            T obj = Activator.CreateInstance<T>();
            if (row != null)
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    if (row.Table.Columns.Contains(property.Name.ToUpper()))
                    {
                        if (row[property.Name.ToUpper()] != System.DBNull.Value)
                            property.SetValue(obj, row[property.Name.ToUpper()], null);
                    }


                    //根据自定义的标签名称对应数据表中的数据，进行匹配，匹配成功，进行映射绑值
                    //object[] objTable = property.GetCustomAttributes(typeof(DataFieldAttribute), false);

                    //if (row.Table.Columns.Contains(((DataFieldAttribute)objTable[0]).FieldName))
                    //{
                    //    if (row[((DataFieldAttribute)objTable[0]).FieldName] != System.DBNull.Value)
                    //    {
                    //        property.SetValue(obj, row[property.Name.ToUpper()], null);
                    //    }

                    //}
                }

            }

            return obj;
        }
        #endregion

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name.ToUpper());
                //table.Columns.Add(prop.Name, prop.PropertyType);   
            }

            return table;
        }
    }
}
