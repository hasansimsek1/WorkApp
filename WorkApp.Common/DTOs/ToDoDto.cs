namespace WorkApp.Common.DTOs
{
    public class ToDoDto : DtoBase
    {
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
