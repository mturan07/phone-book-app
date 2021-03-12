using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    interface IReportDal : IEntityRepository<Report>
    {
    }
}
