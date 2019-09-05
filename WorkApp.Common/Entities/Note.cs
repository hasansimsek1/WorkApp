using System;
using System.Collections.Generic;
using System.Text;

namespace WorkApp.Common.Entities
{
    public class Note : EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<NoteTag> Tags { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
