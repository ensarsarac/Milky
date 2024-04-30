using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.DataAccessLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly MilkyContext _milkyContext;

        public StatisticController( MilkyContext milkyContext)
        {
            _milkyContext = milkyContext;
        }

        [HttpGet("CustomerCount")]
        public IActionResult CustomerCount()
        {
            var values = _milkyContext.Users.Count();
            return Ok(values);
        }
        [HttpGet("Experience")]
        public IActionResult Experience()
        {
            return Ok("25");
        }
        [HttpGet("TotalAnimals")]
        public IActionResult TotalAnimals()
        {
            return Ok("560");
        }
        [HttpGet("Award")]
        public IActionResult Award()
        {
            return Ok("150");
        }
    }
}
