using System;

namespace Brevitee.Schema.Org
{
	///<summary>A short radio program or a segment/part of a radio program.</summary>
	public class RadioClip: Clip
	{
		///<summary>The season to which this episode belongs.</summary>
		public Season PartOfSeason {get; set;}
		///<summary>The series to which this episode or season belongs. Supersedes partOfTVSeries.</summary>
		public Series PartOfSeries {get; set;}
	}
}
