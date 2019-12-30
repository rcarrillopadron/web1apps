using System.Collections.Generic;
using System.Threading.Tasks;
using Web1Apps.Shared;

namespace Web1Apps.Server.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
