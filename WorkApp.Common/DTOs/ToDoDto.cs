using WorkApp.Common.Entities;

namespace WorkApp.Common.DTOs
{
    public class ToDoDto : DtoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCompleted { get; set; }


        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
