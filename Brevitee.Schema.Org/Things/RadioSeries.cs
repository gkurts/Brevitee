using System;

namespace Brevitee.Schema.Org
{
	///<summary>Series dedicated to radio broadcast and associated online delivery.</summary>
	public class RadioSeries: Series
	{
		///<summary>A cast member of the movie, tv/radio series, season, episode, or video. Supersedes actors.</summary>
		public Person Actor {get; set;}
		///<summary>The director of the movie, tv/radio episode or series. Supersedes directors.</summary>
		public Person Director {get; set;}
		///<summary>An episode of a TV/radio series or season Supersedes episodes.</summary>
		public Episode Episode {get; set;}
		///<summary>The composer of the movie or TV/radio soundtrack.</summary>
		public ThisOrThat<MusicGroup , Person> MusicBy {get; set;}
		///<summary>The number of episodes in this season or series.</summary>
		public Number NumberOfEpisodes {get; set;}
		///<summary>The producer of the movie, tv/radio series, season, or episode, or video.</summary>
		public Person Producer {get; set;}
		///<summary>The production company or studio that made the movie, tv/radio series, season, or episode, or media object.</summary>
		public Organization ProductionCompany {get; set;}
		///<summary>A season in a tv/radio series. Supersedes seasons.</summary>
		public Season Season {get; set;}
		///<summary>The trailer of a movie or tv/radio series, season, or episode.</summary>
		public VideoObject Trailer {get; set;}
	}
}
