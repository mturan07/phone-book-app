using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Constants;
using WebApi.DataAccess;
using WebApi.Models;
using WebApi.Utilities;

namespace WebApi.Business
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

        public IDataResult<ContactInfo> GetById(Guid contactId)
        {
            return new SuccessDataResult<ContactInfo>(_contactInfoDal.Get(c => c.ContactId == contactId));
        }

        public IDataResult<List<ContactInfo>> GetList()
        {
            return new SuccessDataResult<List<ContactInfo>>(_contactInfoDal.GetList(), Messages.ContactsListed);
        }
    }
}
