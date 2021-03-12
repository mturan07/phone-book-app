using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
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
