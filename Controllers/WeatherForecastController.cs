using DockerTest.Data;
using DockerTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DockerTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

       
        private readonly ApplicationDbContext _context;

        public WeatherForecastController(ApplicationDbContext context)
        {
            _context = context;
        }

        
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetComments()
        {
            if (_context.Tests == null)
            {
                return NotFound();
            }
            return await _context.Tests.ToListAsync();
        }

    }
}
