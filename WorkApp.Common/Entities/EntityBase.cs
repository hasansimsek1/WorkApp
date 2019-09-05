using System;
using WorkApp.Common.Interfaces;

namespace WorkApp.Common.Entities
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
