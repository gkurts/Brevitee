using System;

namespace Brevitee.Schema.Org
{
	///<summary>A movie.</summary>
	public class Movie: CreativeWork
	{
		///<summary>A cast member of the movie, tv/radio series, season, episode, or video. Supersedes actors.</summary>
		public Person Actor {get; set;}
		///<summary>The director of the movie, tv/radio episode or series. Supersedes directors.</summary>
		public Person Director {get; set;}
		///<summary>The duration of the item (movie, audio recording, event, etc.) in ISO 8601 date format.</summary>
		public Duration Duration {get; set;}
		///<summary>The composer of the movie or TV/radio soundtrack.</summary>
		public ThisOrThat<Person , MusicGroup> MusicBy {get; set;}
		///<summary>The producer of the movie, tv/radio series, season, or episode, or video.</summary>
		public Person Producer {get; set;}
		///<summary>The production company or studio that made the movie, tv/radio series, season, or episode, or media object.</summary>
		public Organization ProductionCompany {get; set;}
		///<summary>The trailer of a movie or tv/radio series, season, or episode.</summary>
		public VideoObject Trailer {get; set;}
	}
}
