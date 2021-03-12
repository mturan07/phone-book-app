using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
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
