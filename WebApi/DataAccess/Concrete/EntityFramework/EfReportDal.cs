using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataAccess.Abstract.EntityFramework;
using WebApi.Models;

namespace WebApi.DataAccess.Concrete.EntityFramework
{
    public class EfReportDal : EfEntityRepositoryBase<Report, WebApiDBContext>, IReportDal
    {
    }
}
