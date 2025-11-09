using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCQRS.Api.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/post")]
    public class PostController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok("Here is the Version '2.0' & The post N°" + id);
        }
    }
}
