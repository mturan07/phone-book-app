using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Constants;
using WebApi.DataAccess;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Utilities;

namespace WebApi.Business
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult(Messages.ContactAdded);
        }

        public IResult Delete(Contact contact)
        {
            _contactDal.Delete(contact);
            return new SuccessResult(Messages.ContactDeleted);
        }

        public IDataResult<Contact> GetById(Guid contactId)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(c => c.ContactId == contactId));
        }

        public IDataResult<List<Contact>> GetList()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetList(), Messages.ContactsListed);
        }

        public IDataResult<List<ContactDetailDto>> GetContactDetails()
        {
            return new SuccessDataResult<List<ContactDetailDto>>(_contactDal.GetContactDetails(), Messages.ContactDetailsListed);
        }
    }
}
