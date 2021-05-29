using System;

namespace WorkApp.Common.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime AddedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
