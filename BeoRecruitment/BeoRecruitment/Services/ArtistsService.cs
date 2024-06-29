using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeoRecruitment.Models.Entities;
using BeoRecruitment.Services.Interfaces;

namespace BeoRecruitment.Services
{
    public class ArtistsService : IArtistsService
    {
        private readonly ISpotifyAPIService spotifyAPIService;

        public ArtistsService(ISpotifyAPIService spotifyAPIService)
        {
            this.spotifyAPIService = spotifyAPIService;
        }

        public async Task<List<Artist>> GetArtistsAsync(string keyword)
        {
            string token = await spotifyAPIService.GetSpotifyAccessTokenAsync();
            List<Artist> artists = await spotifyAPIService.SearchSpotifyAsync(keyword, token);
            return artists;
        }
    }
}
