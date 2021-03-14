using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ReportDetail : IEntity
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public int NumberOfPeople { get; set; }
        public int NumberOfPhone { get; set; }

        public Guid ReportId { get; set; }
        public Report Report { get; set; }
    }
}
