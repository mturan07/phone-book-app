using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactInfoDal : EfEntityRepositoryBase<ContactInfo, WebApiDBContext>, IContactInfoDal
    {
    }
}
