using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public interface IContactInfoDal : IEntityRepository<ContactInfo>
    {
    }
}
