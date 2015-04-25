using System;

namespace Brevitee.Schema.Org
{
	///<summary>A musical group, such as a band, an orchestra, or a choir. Can also be a solo musician.</summary>
	public class MusicGroup: PerformingGroup
	{
		///<summary>A music album. Supersedes albums.</summary>
		public MusicAlbum Album {get; set;}
		///<summary>A music recording (track)—usually a single song. Supersedes tracks.</summary>
		public MusicRecording Track {get; set;}
	}
}
