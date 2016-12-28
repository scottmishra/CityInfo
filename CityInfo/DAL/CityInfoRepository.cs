using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.DatabaseContexts;
using CityInfo.DAL.Interfaces;
using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.DAL
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsyc()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == cityId);
        }

        public async Task<PointOfInterest> GetPointOfInterestForCityById(int cityId, int pointId)
        {
            return await _context.PointOfInterests.FirstOrDefaultAsync(p => p.CityId == cityId && p.Id == pointId);
        }

        public async Task AddCity(City city)
        {
            await _context.Cities.AddAsync(city);
        }
    }
}