using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models.DTOs;
using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{

    /// <summary>
    /// City Controller class for API, returns cities based on api route.
    /// The base route is "api/cities"
    /// </summary>
    [Route("api/cities")]
    public class CityController : Controller
    {

        private CitiesDataStore _dataStore;

        public CityController(CitiesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        /// <summary>
        /// Returns list of all cities wrapped in JsonResult
        /// Default method called from the base route "api/cities"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await _dataStore.GetAllCities());
        }

        /// <summary>
        /// Returns City that matches the id passed in on the route wrapped in a
        /// JsonResult. Method is called when the route "api/cities/{id}" is called
        /// Will return an empty result set if there is no id matching the passed in id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JsonResult</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var cities = await _dataStore.GetAllCities();
            var cityToReturn = cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }

        /// <summary>
        /// Adds a new city with a Name and Description to the data store, city parameter is only
        /// name and description, the points of interest use the points of interest controller
        /// </summary>
        /// <param name="newCity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateCity([FromBody] CreateCityDto newCity)
        {
            if (newCity == null)
            {
                return BadRequest("no new city");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("city object is poorly formatted");
            }
            var cityToAdd = new CityDto();

            cityToAdd.Name = newCity.Name;
            cityToAdd.Desciption = newCity.Description;

            await _dataStore.AddCity(cityToAdd);

            return Ok(cityToAdd);
        }
    }
}