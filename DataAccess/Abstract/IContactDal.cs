using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactDal : IEntityRepository<Contact>
    {
        List<ContactDetailDto> GetContactDetails();
    }
}
