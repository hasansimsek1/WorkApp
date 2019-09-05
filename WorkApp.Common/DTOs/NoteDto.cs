using System;
using System.Collections.Generic;
using WorkApp.Common.Entities;

namespace WorkApp.Common.DTOs
{
    public class NoteDto : DtoBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<NoteTag> Tags { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
