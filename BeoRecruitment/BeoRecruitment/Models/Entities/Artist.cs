using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeoRecruitment.Models.Entities
{
    public class Artist
    {
        public Artist(string artistID, string artistName, string artistImageURL, string genres, string followerCount, string externalURL) 
        { 
            ArtistID = artistID;
            ArtistName = artistName;
            ArtistImageURL = artistImageURL;
            Genres = genres;
            FollowerCount = followerCount;
            ExternalURL = externalURL;
        }
        public string ArtistID { get; set; }

        public string ArtistName { get; set; }

        public string ArtistImageURL { get; set; }

        public string Genres { get; set; }

        public string FollowerCount { get; set; }

        public string ExternalURL { get; set; }
    }
}
