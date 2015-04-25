using System;

namespace Brevitee.Schema.Org
{
	///<summary>A TV or radio season.</summary>
	public class Season: CreativeWork
	{
		///<summary>The end date and time of the role, event or item (in ISO 8601 date format).</summary>
		public Date EndDate {get; set;}
		///<summary>An episode of a TV/radio series or season Supersedes episodes.</summary>
		public Episode Episode {get; set;}
		///<summary>The number of episodes in this season or series.</summary>
		public Number NumberOfEpisodes {get; set;}
		///<summary>The series to which this episode or season belongs. Supersedes partOfTVSeries.</summary>
		public Series PartOfSeries {get; set;}
		///<summary>The producer of the movie, tv/radio series, season, or episode, or video.</summary>
		public Person Producer {get; set;}
		///<summary>The production company or studio that made the movie, tv/radio series, season, or episode, or media object.</summary>
		public Organization ProductionCompany {get; set;}
		///<summary>Position of the season within an ordered group of seasons.</summary>
		public ThisOrThat<Integer , Text> SeasonNumber {get; set;}
		///<summary>The start date and time of the event, role or item (in ISO 8601 date format).</summary>
		public Date StartDate {get; set;}
		///<summary>The trailer of a movie or tv/radio series, season, or episode.</summary>
		public VideoObject Trailer {get; set;}
	}
}
