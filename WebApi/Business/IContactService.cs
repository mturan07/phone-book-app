using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Utilities;

namespace WebApi.Business
{
    public interface IContactService
    {
        IDataResult<Contact> GetById(Guid contactId);

        IDataResult<List<Contact>> GetList();

        IResult Add(Contact contact);

        //IResult Update(Contact contact);

        IResult Delete(Contact contact);

        IDataResult<List<ContactDetailDto>> GetContactDetails();
    }
}
