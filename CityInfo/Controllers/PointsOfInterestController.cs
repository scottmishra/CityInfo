using System;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models.DTOs;
using CityInfo.Services;
using CityInfo.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfo.Controllers
{
    /// <summary>
    /// Controller to handle the look up of points of interest for cities.
    /// Since Points of Interest are children elements of a city, the base route for this
    /// controller will start at "api/cities"
    /// </summary>
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;
        private IMailService _mailService;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,
            IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        /// <summary>
        /// Return the list of points of interest for a given city id. If the city id
        /// doesnt exist return a 404 not found result
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
//        [HttpGet("{cityId}/pointsofinterest")]
//        public async Task<IActionResult> GetAllPointsOfInterestForACity(int cityId)
//        {
//            try
//            {
//                var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
//                if (city == null)
//                {
//                    _logger.LogInformation($"{cityId} wasn't found, returning NotFound result");
//                    return NotFound();
//                }
//                var pointsOfInterest = city.PointsOfInterest;
//                return Ok(pointsOfInterest);
//            }
//            catch (Exception)
//            {
//                _logger.LogCritical($"an error occured while getting the city for cityId: {cityId}");
//               return StatusCode(500, "Exception occured reading the city data store");
//            }
//
//        }

//        [HttpGet("{cityId}/pointsofinterest/{id}",Name = "GetPointOfInterestForACity")]
//        public async Task<IActionResult> GetPointOfInterestForACity(int cityId, int id)
//        {
//            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
//            if (city == null)
//            {
//                return NotFound();
//            }
//            var point = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
//            if (point == null)
//            {
//                return NotFound();
//            }
//            return Ok(point);
//        }

//        [HttpPost("{cityId}/pointsofinterest")]
//        public async Task<IActionResult> CreatePointOfInterest(int cityId, [FromBody] PointOfInterestCreationDto pointOfInterest)
//        {
//            //Return Bad Request if the point of intest isn't serialized
//            if (pointOfInterest == null)
//            {
//                return BadRequest("missing point of interest body");
//            }
//            //Check the created Model State
//            if (!ModelState.IsValid)
//            {
//                return BadRequest("Bad Point of Interest sent in the Body");
//            }
//            // Check for the city based on cityId depending and return not found if it isnt in the store
//            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
//            if (city == null)
//            {
//                return NotFound();
//            }
//            //Map the DTOs.
//            var maxId = city.PointsOfInterest.Max(point => point.Id);
//            var newPoint = new PointOfInterestDto
//            {
//                Id = ++maxId,
//                Description = pointOfInterest.Description,
//                Name = pointOfInterest.Name
//            };
//            city.PointsOfInterest.Add(newPoint);
//            return CreatedAtRoute("GetPointOfInterestForACity",
//            new {cityId = cityId,Id = newPoint.Id},newPoint);
//        }

//        [HttpPatch("{cityId}/pointsofinterest/{id}")]
//        public async Task<IActionResult> UpdatePointOfInterest(int cityId, int id,
//            [FromBody] JsonPatchDocument<PointOfInterestUpdateDto> patchDocument)
//        {
//            if (patchDocument == null)
//            {
//                return BadRequest("Missing Patch Body");
//            }
//            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
//            if (city == null)
//            {
//                return NotFound();
//            }
//            var point = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
//            if (point == null)
//            {
//                return NotFound();
//            }
//            var pointOfInterestUpdate = new PointOfInterestUpdateDto
//            {
//                Name = point.Name,
//                Description = point.Description
//            };
//
//            //Passing in the Model State will allow us to check for errors after attempting to apply the patch
//            //document to the DTO.
//            patchDocument.ApplyTo(pointOfInterestUpdate, ModelState);
//            if (!ModelState.IsValid)
//            {
//                return BadRequest("PAtch request is not formatted properly");
//            }
//            //Validate the update dto since the model state above is only for the patch doc
//            TryValidateModel(pointOfInterestUpdate);
//            if (!ModelState.IsValid)
//            {
//                return BadRequest("PAtch request is not formatted properly");
//            }
//            //Copy over the values from the updateDTO back to the storage DTO
//            point.Name = pointOfInterestUpdate.Name;
//            point.Description = pointOfInterestUpdate.Description;
//            return Ok(point);
//        }

//        //Delete Point of Interest
//        [HttpDelete("{cityId}/pointsofinterest/{id}")]
//        public async Task<IActionResult> DeletePointOfInterest(int cityId, int id)
//        {
//            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
//            if (city == null)
//            {
//                return NotFound();
//            }
//            var point = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
//            if (point == null)
//            {
//                return NotFound();
//            }
//            city.PointsOfInterest.Remove(point);
//
//            _mailService.Send($"Deleting PoI",$"Deleting {point}");
//
//            return Ok(point);
//        }
    }
}