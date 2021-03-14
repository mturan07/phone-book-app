using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _contactService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _contactService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Details")]
        public IActionResult GetContactDetails()
        {
            var result = _contactService.GetContactDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Details/{id}")]
        public IActionResult GetContactDetails(Guid id)
        {
            var result = _contactService.GetContactDetails();
            if (result.Success)
            {
                // TODO: burası refactor edilecek
                IEnumerable<ContactDetailDto> contactDetail = result.Data.Where(c => c.ContactId == id);
                return Ok(contactDetail);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Contact contact)
        {
            var result = _contactService.Add(contact);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("update")]
        //public IActionResult Update([FromBody] Contact contact)
        //{
        //    var result = _contactService.Update(contact);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }

        //    return BadRequest(result.Message);
        //}

        [HttpDelete]
        public IActionResult Delete([FromBody] Contact contact)
        {
            var result = _contactService.Delete(contact);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
