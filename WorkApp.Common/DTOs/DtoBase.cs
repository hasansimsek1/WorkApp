using System;
using WorkApp.Common.Interfaces;

namespace WorkApp.Common.DTOs
{
    public class DtoBase : IDto
    {
        public int Id { get; set; } = 0;
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
