using System;
namespace Brevitee.Data.Repositories
{
	public interface IMetaProvider
	{
		Meta GetMeta(object data);
	}
}
