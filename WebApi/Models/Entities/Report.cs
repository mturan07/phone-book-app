using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Report
    {
        public Guid ReportId { get; set; }
        public DateTime RequestDate { get; set; }
        public string State { get; set; }
    }
}
