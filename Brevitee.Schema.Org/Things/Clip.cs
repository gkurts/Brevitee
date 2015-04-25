using System;

namespace Brevitee.Schema.Org
{
	///<summary>A short TV or radio program or a segment/part of a program.</summary>
	public class Clip: CreativeWork
	{
		///<summary>Position of the clip within an ordered group of clips.</summary>
		public ThisOrThat<Integer , Text> ClipNumber {get; set;}
		///<summary>The episode to which this clip belongs.</summary>
		public Episode PartOfEpisode {get; set;}
		///<summary>The season to which this episode belongs.</summary>
		public Season PartOfSeason {get; set;}
		///<summary>The series to which this episode or season belongs. Supersedes partOfTVSeries.</summary>
		public Series PartOfSeries {get; set;}
		///<summary>A publication event associated with the episode, clip or media object.</summary>
		public PublicationEvent Publication {get; set;}
	}
}
