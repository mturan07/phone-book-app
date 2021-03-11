using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.DataAccess
{
    public interface IContactDal : IRepositoryEntities<Contact>
    {
        List<ContactDetailDto> GetContactDetails();
    }
}
