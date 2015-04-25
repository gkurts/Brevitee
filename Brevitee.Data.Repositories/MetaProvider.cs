using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Repositories
{
	public class MetaProvider : Brevitee.Data.Repositories.IMetaProvider
	{
		public MetaProvider(IObjectReaderWriter objectReaderWriter)
		{
			this.ObjectReaderWriter = objectReaderWriter;
		}

		
		static IMetaProvider _default;
		static object _defaultLock = new object();
		public static IMetaProvider Default
		{
			get
			{
				return _defaultLock.DoubleCheckLock(ref _default, () => new MetaProvider(Brevitee.Data.Repositories.ObjectReaderWriter.Default));
			}
		}

		public IObjectReaderWriter ObjectReaderWriter { get; set; }

		public virtual Meta GetMeta(object data)
		{
			return new Meta(data, ObjectReaderWriter);
		}
	}
}
