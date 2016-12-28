using CityInfo.DatabaseContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Controllers
{
    public class DumbyController : Controller
    {
        private CityInfoContext _context;
        public DumbyController(CityInfoContext context)
        {
            _context = context;
        }

        [HttpGet("api/dumby")]
        public IActionResult DumbyGetMethod()
        {
            return Ok();
        }
    }
}