using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        IContactInfoDal _contactInfoDal;

        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            _contactInfoDal = contactInfoDal;
        }

        public IResult Add(ContactInfo contactInfo)
        {
            _contactInfoDal.Add(contactInfo);
            return new SuccessResult(Messages.ContactAdded);
        }

        public IResult Delete(ContactInfo contactInfo)
        {
            _contactInfoDal.Delete(contactInfo);
            return new SuccessResult(Messages.ContactDeleted);
        }

        public IDataResult<Task<ContactInfo>> GetById(Guid contactId)
        {
            return new SuccessDataResult<Task<ContactInfo>>(_contactInfoDal.Get(c => c.ContactId == contactId));
        }

        public IDataResult<List<ContactInfo>> GetList()
        {
            return new SuccessDataResult<List<ContactInfo>>(_contactInfoDal.GetList(), Messages.ContactsListed);
        }
    }
}
