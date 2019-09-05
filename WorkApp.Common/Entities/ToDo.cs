namespace WorkApp.Common.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ToDo : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCompleted { get; set; }


        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
