using Microsoft.AspNetCore.Mvc;

namespace webapi;
[Route("[controller]/{action}")]
[ApiController]
public class HomeController : ControllerBase
{
    public ActionResult<string> Get()
    {
        return "ActionResult<string>";
    }
}
