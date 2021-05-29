using WorkApp.Common.Interfaces;

namespace WorkApp.Common.DTOs
{
    public class DtoBase : IDto
    {
        public int? Id { get; set; }
    }
}
