using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataAccess.Abstract.EntityFramework;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Utilities;

namespace WebApi.DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, WebApiDBContext>, IContactDal
    {
        public List<ContactDetailDto> GetContactDetails()
        {
            using (WebApiDBContext context = new WebApiDBContext())
            {
                var result = from c in context.Contacts
                             join i in context.ContactInfos
                             on c.ContactId equals i.ContactId
                             select new ContactDetailDto
                             {
                                 ContactId = c.ContactId,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Company = c.Company,
                                 InfoType = i.InfoType,
                                 Description = i.Description
                             };
                return result.ToList();
            }
        }
    }
}
