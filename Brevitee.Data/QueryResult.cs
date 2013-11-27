using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Brevitee.Data
{
    public abstract class QueryResult: IHasDataTable
    {
        #region IHasDataTable Members

        public DataTable DataTable
        {
            get;
            protected set;
        }

        public DataRow DataRow
        {
            get
            {
                return DataTable.Rows[0];
            }
            set { }
        }

        public abstract void SetDataTable(DataTable table);

        /// <summary>
        /// Instantiates a new instance of T and calls SetDataTable passing
        /// in the DataTable from the current instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T As<T>() where T : IHasDataTable, new()
        {
            T val = new T();
            val.SetDataTable(this.DataTable);
            return val;
        }

        #endregion
    }
}
