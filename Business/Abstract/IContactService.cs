using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IDataResult<Contact> GetById(Guid contactId);

        IDataResult<List<Contact>> GetAll();

        IResult Add(Contact contact);

        //IResult Update(Contact contact);

        IResult Delete(Contact contact);

        IDataResult<List<ContactDetailDto>> GetContactDetails();
    }
}
