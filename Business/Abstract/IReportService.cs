using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReportService
    {
        IDataResult<Report> GetById(Guid reportId);

        IDataResult<List<Report>> GetAll();

        IResult Add(Report report);

        //IResult Update(Contact report);

        IResult Delete(Report report);

        IDataResult<List<ReportDetail>> GetReportDetail();

        //IDataResult<ReportDetail> getReportByLocation(Guid reportId);

        /*         
            from r in db.Rider
            join s in db.Spaces
                on r.SpaceID equals s.SpaceID
            group new { r,s } by new { r.SpaceID, s.SpaceCode }
            into grp
            select new
            {
                Count=grp.Count(),
                grp.Key.SpaceID,
                grp.Key.SpaceCode
            }
        
        */
    }
}
