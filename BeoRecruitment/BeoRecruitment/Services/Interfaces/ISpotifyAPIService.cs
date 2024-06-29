using BeoRecruitment.Models.Entities;
using BeoRecruitment.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeoRecruitment.Services.Interfaces
{
    public interface ISpotifyAPIService
    {
        Task<string> GetSpotifyAccessTokenAsync();

        Task<List<Artist>> SearchSpotifyAsync(string keyword, string token);
    }
}
