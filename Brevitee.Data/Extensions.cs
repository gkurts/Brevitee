using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Data.Common;
using System.Data;
using System.Collections;

namespace Brevitee.Data
{
    public static class Extensions
    {
        public static object ToJsonSafe(this object obj)
        {
            Type jsonSafeType = obj.CreateDynamicType<ColumnAttribute>(false);// CreateDynamicType<DaoColumn>(daoObject, false);
            ConstructorInfo ctor = jsonSafeType.GetConstructor(new Type[] { });
            object jsonSafeInstance = ctor.Invoke(null);//Activator.CreateInstance(jsonSafeType);
            jsonSafeInstance.CopyProperties(obj);
            return jsonSafeInstance;
        }

        public static object[] ToJsonSafe(this IEnumerable e)
        {
            List<object> returnValues = new List<object>();
            foreach (object o in e)
            {
                returnValues.Add(o.ToJsonSafe());
            }

            return returnValues.ToArray();
        }

		public static List<object> ToListOf(this DataTable table, Type type, bool throwIfColumnPropertyNotFound = false)
		{
			List<object> result = new List<object>();
			foreach (DataRow row in table.Rows)
			{
				result.Add(row.ToInstanceOf(type, throwIfColumnPropertyNotFound));
			}

			return result;
		}

		public static List<T> ToListOf<T>(this DataTable table, bool throwIfColumnPropertyNotFound = false)
		{
			List<T> result = new List<T>();
			foreach(DataRow row in table.Rows)
			{
				result.Add(row.ToInstanceOf<T>(throwIfColumnPropertyNotFound));
			}

			return result;
		}

		public static T ToInstanceOf<T>(this DataRow row, bool throwIfColumnPropertyNotFound = false)
		{
			return (T)row.ToInstanceOf(typeof(T), throwIfColumnPropertyNotFound);
		}

		public static object ToInstanceOf(this DataRow row, Type type, bool throwIfColumnPropertyNotFound = false)
		{
			object result = type.Construct();
			foreach(DataColumn column in row.Table.Columns)
			{
				object value = row[column];
				result.Property(column.ColumnName, value, throwIfColumnPropertyNotFound);
			}
			return result;
		}
		
		public static DataRow ToDataRow(this object instance, string tableName = null)
		{
			Type instanceType = instance.GetType();
			tableName = tableName ?? instanceType.Name;
			PropertyInfo[] properties = instanceType.GetProperties();

			DataTable table = new DataTable(tableName);
			List<object> rowValues = new List<object>();
			foreach (PropertyInfo property in properties)
			{
				ColumnAttribute column;
				if (property.HasCustomAttributeOfType<ColumnAttribute>(true, out column))
				{
					table.Columns.Add(column.Name);
					rowValues.Add(property.GetValue(instance, null));
				}
			}

			return table.Rows.Add(rowValues.ToArray());
		}
    }
}
