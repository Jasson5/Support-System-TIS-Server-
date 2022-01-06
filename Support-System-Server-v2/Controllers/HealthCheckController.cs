using Microsoft.AspNetCore.Mvc;

//Control de salud del backend(se muestra si esta funcionando)

namespace Support_System_Server_v2.Controllers
{

    [Route("api/health-check")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Service running.");
        }
    }
}
