using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1Apps.Shared;

namespace Web1Apps.Api.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
