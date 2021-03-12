using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactInfoService
    {
        IDataResult<ContactInfo> GetById(Guid contactId);

        IDataResult<List<ContactInfo>> GetList();

        IResult Add(ContactInfo contactInfo);

        //IResult Update(Contact contact);

        IResult Delete(ContactInfo contactInfo);
    }
}
