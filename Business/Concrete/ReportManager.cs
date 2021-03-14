using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class ReportManager : IReportService
    {
        IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public IResult Add(Report report)
        {
            _reportDal.Add(report);
            return new SuccessResult(Messages.ReportAdded);
        }

        public IResult Delete(Report report)
        {
            _reportDal.Delete(report);
            return new SuccessResult(Messages.ReportDeleted);
        }

        public IDataResult<Report> GetById(Guid reportId)
        {
            return new SuccessDataResult<Report>(_reportDal.GetById(c => c.ReportId == reportId));
        }

        public IDataResult<List<Report>> GetAll()
        {
            return new SuccessDataResult<List<Report>>(_reportDal.GetAll(), Messages.ReportsListed);
        }

        public IDataResult<List<ReportDetail>> GetReportDetail()
        {
            return null; //new SuccessDataResult<List<ReportDetail>>(_reportDal.(), Messages.ReportDetailsListed);
        }
    }
}
