using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Utilities;

namespace WebApi.Business
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();

        IResult Add(Contact contact);
    }
}
