using LibraryAppBackend.Business.Interfaces;
using LibraryAppBackend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorBusiness _business;

        public AuthorController(IAuthorBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            var response = _business.Save(author);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}