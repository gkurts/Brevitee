using System;
namespace Brevitee.Logging
{
	public interface IDaoLogger: ILogger
	{
		Brevitee.Data.Database Database { get; set; }
	}
}
