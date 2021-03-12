using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    public class Contact : IEntity
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public ICollection<ContactInfo> ContactInfo { get; set; }
    }
}
