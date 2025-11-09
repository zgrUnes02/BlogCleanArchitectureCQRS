using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCQRS.Api.Controllers.V1
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/post")]
    public class PostController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok("Here is the Version '1.0' & The post N°" + id);
        }
    }
}
