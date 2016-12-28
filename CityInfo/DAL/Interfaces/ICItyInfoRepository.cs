using System.Collections.Generic;
using System.Threading.Tasks;
using CityInfo.Entities;

namespace CityInfo.DAL.Interfaces
{
    public interface ICityInfoRepository
    {
        /// <summary>
        /// Return all the cites from the DataStore
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<City>> GetAllCitiesAsyc();

        /// <summary>
        /// Return the city based on the requested Id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<City> GetCityByIdAsync(int cityId);

        /// <summary>
        /// Return a specified point of interest of a desired city
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="pointId"></param>
        /// <returns></returns>
        Task<PointOfInterest> GetPointOfInterestForCityById(int cityId, int pointId);

        Task AddCity(City city);
    }
}