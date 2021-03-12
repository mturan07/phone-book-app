using Core.Entities;
using System;

namespace Entities.Concrete
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
