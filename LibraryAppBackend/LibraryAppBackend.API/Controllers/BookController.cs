using LibraryAppBackend.Business.Interfaces;
using LibraryAppBackend.Entities;
using LibraryAppBackend.Transversal.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _business;

        public BookController(IBookBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            var response = _business.Save(book);
            return StatusCode((int)response.StatusCode, response);
        }

        [Route("Search")]
        [HttpPost]
        public IActionResult Search([FromBody] BookFilters filters)
        {
            var response = _business.Search(filters);
            return Ok(response);
        }
    }
}