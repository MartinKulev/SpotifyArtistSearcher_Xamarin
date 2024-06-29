using System.Collections.Generic;

namespace BeoRecruitment.Services.Interfaces
{
    /// <summary>
    /// An example service providing data
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Provide data based on <paramref name="id"/>.
        /// </summary>
        IEnumerable<string> GetData(int id);
    }
}

