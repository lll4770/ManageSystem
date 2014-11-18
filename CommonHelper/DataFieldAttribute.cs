using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    //描述数据库字段的 Attribute 
    public class DataFieldAttribute : Attribute
    {
        public DataFieldAttribute(string fieldName, string fieldType)
        {
            this._fieldName = fieldName;
            this._fieldType = fieldType;
        }

        // 数据库字段名 
        private string _fieldName;
        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        // 数据库字段类型 
        private string _fieldType;
        public string FieldType
        {
            get { return _fieldType; }
            set { _fieldType = value; }
        }
    } 

}
