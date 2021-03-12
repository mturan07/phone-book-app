using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    public class ContactInfo : IEntity
    {
        public Guid Id { get; set; }
        public string InfoType { get; set; }
        public string Description { get; set; }

        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
