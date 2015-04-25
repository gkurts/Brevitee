using System;

namespace Brevitee.Schema.Org
{
	///<summary>A short TV program or a segment/part of a TV program.</summary>
	public class TVClip: Clip
	{
		///<summary>The season to which this episode belongs.</summary>
		public Season PartOfSeason {get; set;}
		///<summary>The series to which this episode or season belongs. Supersedes partOfTVSeries.</summary>
		public Series PartOfSeries {get; set;}
	}
}
