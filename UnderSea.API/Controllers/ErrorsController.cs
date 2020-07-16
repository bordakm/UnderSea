using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace UnderSea.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}
