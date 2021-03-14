using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoesController : ControllerBase
    {
        IContactInfoService _contactInfoService;

        public ContactInfoesController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _contactInfoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _contactInfoService.GetAll();
            if (result.Success)
            {
                IEnumerable<ContactInfo> contactInfos = result.Data.Where(c => c.ContactId == id);
                return Ok(contactInfos);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ContactInfo contactInfo)
        {
            var result = _contactInfoService.Add(contactInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("update")]
        //public IActionResult Update([FromBody] ContactInfo contactInfo)
        //{
        //    var result = _contactInfoService.Update(contactInfo);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }

        //    return BadRequest(result.Message);
        //}

        [HttpDelete]
        public IActionResult Delete([FromBody] ContactInfo contactInfo)
        {
            var result = _contactInfoService.Delete(contactInfo);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
