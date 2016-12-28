using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.DAL;
using CityInfo.DAL.Interfaces;
using CityInfo.Entities;
using CityInfo.Models.DTOs;

namespace CityInfo.Services
{
    /// <summary>
    /// Simple in-memory data store with dummy data to help develop the
    /// api, and have a default set of data to return
    /// </summary>
    public class CitiesDataStore
    {
        public List<CityDto> Cities;
        private ICityInfoRepository _repository;
        public CitiesDataStore(ICityInfoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CityDto>> GetAllCities()
        {
            var cities = await _repository.GetAllCitiesAsyc();
            var cityDTOs = MapCityToCityDtos(cities);
            return cityDTOs;
        }

        public async Task AddCity(CityDto city)
        {
            var wrappedCity = new List<CityDto>
            {
                city
            };
            var cities = MapCityDTOToCity(wrappedCity);
            _repository.AddCity(cities.First());
        }

        private IEnumerable<CityDto> MapCityToCityDtos(IEnumerable<City> cities)
        {
            return cities.Select(city => new CityDto
                {
                    Id = city.Id,
                    Name = city?.Name,
                    Desciption = city?.Description,
                    PointsOfInterest = MapPointsOfInterest(city.PointsOfInterest)
                })
                .ToList();
        }

        private ICollection<PointOfInterestDto> MapPointsOfInterest(ICollection<PointOfInterest> cityPointsOfInterest)
        {
            return cityPointsOfInterest.Select(pointOfInterest => new PointOfInterestDto
                {
                    Id = pointOfInterest.Id,
                    Description = pointOfInterest?.Description,
                    Name = pointOfInterest?.Name
                })
                .ToList();
        }

        private IEnumerable<City> MapCityDTOToCity(IEnumerable<CityDto> cities)
        {
            return cities.Select(city => new City
                {
                    Name = city?.Name,
                    Description = city?.Desciption,
                    PointsOfInterest = MapPointsOfInterestDTO(city.PointsOfInterest)
                })
                .ToList();
        }

        private ICollection<PointOfInterest> MapPointsOfInterestDTO(ICollection<PointOfInterestDto> cityPointsOfInterest)
        {
            return cityPointsOfInterest.Select(pointOfInterest => new PointOfInterest
                {
                    Description = pointOfInterest?.Description,
                    Name = pointOfInterest?.Name
                })
                .ToList();
        }
    }
}