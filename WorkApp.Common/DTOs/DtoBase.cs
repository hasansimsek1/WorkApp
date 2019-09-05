using System;
using WorkApp.Common.Interfaces;

namespace WorkApp.Common.DTOs
{
    public class DtoBase : IDto
    {
        public int? Id { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
