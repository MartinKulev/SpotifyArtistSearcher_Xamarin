using System.Collections.Generic;
using BeoRecruitment.Services.Interfaces;

namespace BeoRecruitment.Services
{
    public class DataService : IDataService
    {
        public IEnumerable<string> GetData(int id)
        {
            yield return "Luxury";
            yield return "Timeless";
            yield return "Technology";
            if (id > 1000)
            {
                yield return "Bang & Olufsen A/S";
            }
        }
    }
}
