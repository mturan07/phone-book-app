using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Business
{
    public interface IContactService
    {
        List<Contact> GetAll();
    }
}
