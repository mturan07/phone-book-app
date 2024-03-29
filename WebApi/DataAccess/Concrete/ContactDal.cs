﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.DataAccess.Concrete
{
    public class ContactDal : IContactDal
    {       
        public async void Add(Contact entity)
        {
            using (WebApiDBContext context = new WebApiDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }        
        
        public void Update(Contact entity)
        {
            using (WebApiDBContext context = new WebApiDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Contact entity)
        {
            using (WebApiDBContext context = new WebApiDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task<Contact> GetById(Guid contactId)
        {
            using (WebApiDBContext context = new WebApiDBContext())
            {
                return await context.Set<Contact>().SingleOrDefaultAsync(c => c.ContactId == contactId);
            }
        }

        public async Task<List<Contact>> Get()
        {
            using (WebApiDBContext context = new WebApiDBContext())
            {
                return await context.Set<Contact>().ToListAsync();
            }
        }

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
