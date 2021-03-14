using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, WebApiDBContext>, IContactDal
    {

        /**
         * 
         * Join ile birleştirilen iki tablodan belirli alanları ContactDetailDto üzerinden ayıklıyoruz
         * 
         */
        public List<ContactDetailDto> GetContactDetails()
        {
            using (WebApiDBContext context = new WebApiDBContext())
            {
                var result = from c in context.Contacts
                             join i in context.ContactInfos on c.ContactId equals i.ContactId
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
