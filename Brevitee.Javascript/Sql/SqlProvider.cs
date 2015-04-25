using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Brevitee.Data;
using System.Data;
using Brevitee.Configuration;

namespace Brevitee.Javascript.Sql
{
	[Proxy("sql")]
	public abstract class SqlProvider : IConfigurable
	{
		public SqlProvider() { }

		public Database Database
		{
			get;
			set;
		}
		public SqlResponse Execute(string sql)
		{
			EnsureInitialized();
			SqlResponse result = new SqlResponse();
			try
			{
				DataTable results = Database.GetDataTableFromSql(sql, CommandType.Text);
				result.Results = results.ToDynamicList().ToArray();
				result.Count = results.Rows.Count;
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				result.Results = new object[] { };
			}

			return result;
		}

		bool _initialized;
		public void EnsureInitialized()
		{
			if(!_initialized)
			{
				_initialized = true;
				Initialize();				
			}
		}
		protected abstract void Initialize();

		#region IConfigurable Members

		[Exclude]
		public abstract void Configure(IConfigurer configurer);

		[Exclude]
		public abstract void Configure(object configuration);

		#endregion

		#region IHasRequiredProperties Members

		public abstract string[] RequiredProperties { get; }
		#endregion
	}
}
