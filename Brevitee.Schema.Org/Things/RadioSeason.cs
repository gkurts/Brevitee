using System;

namespace Brevitee.Schema.Org
{
	///<summary>Season dedicated to radio broadcast and associated online delivery.</summary>
	public class RadioSeason: Season
	{
		///<summary>An episode of a TV/radio series or season Supersedes episodes.</summary>
		public Episode Episode {get; set;}
		///<summary>The number of episodes in this season or series.</summary>
		public Number NumberOfEpisodes {get; set;}
		///<summary>The series to which this episode or season belongs. Supersedes partOfTVSeries.</summary>
		public Series PartOfSeries {get; set;}
		///<summary>The trailer of a movie or tv/radio series, season, or episode.</summary>
		public VideoObject Trailer {get; set;}
	}
}
