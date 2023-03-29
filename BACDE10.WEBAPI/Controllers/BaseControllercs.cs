using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BACDE10.WEBAPI.Controllers
{
    [ApiController]
    [EnableCors("corsapp")]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {

    }
}
