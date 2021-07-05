using LibraryAppBackend.Business.Interfaces;
using LibraryAppBackend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialBusiness _business;

        public EditorialController(IEditorialBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Editorial editorial)
        {
            var response = _business.Save(editorial);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}