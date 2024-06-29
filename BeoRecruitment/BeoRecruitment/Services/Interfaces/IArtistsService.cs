using BeoRecruitment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeoRecruitment.Services.Interfaces
{
    public interface IArtistsService
    {
        Task<List<Artist>> GetArtistsAsync(string keyword);
    }
}
