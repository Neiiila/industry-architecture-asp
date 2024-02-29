using Microsoft.AspNetCore.Mvc;

namespace  PolyGlotLab.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Index()
        {
            return Problem(); // predifined method frome ControllerBase, that returns a 500 status code 
        }
    }
}
