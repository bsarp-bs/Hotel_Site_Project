using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCategoryController : ControllerBase
    {
        private readonly IContactCategoryService _contactCategoryService;

        public ContactCategoryController(IContactCategoryService contactCategoryService)
        {
            _contactCategoryService = contactCategoryService;
        }

        [HttpGet]
        public IActionResult ContactCategoryGet()
        {
            var value = _contactCategoryService.GetAllS();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult ContactCategoryGetbyid(int id)
        {
            var value = _contactCategoryService.Getbyid(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddContactCategory(ContactCategory cc)
        {
            _contactCategoryService.SInsert(cc);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContactCategory(int id)
        {
            var value = _contactCategoryService.Getbyid(id);
            _contactCategoryService.SDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContactCategory(ContactCategory cc)
        {
            _contactCategoryService.SUpdate(cc);
            return Ok();
        }
    }
}
