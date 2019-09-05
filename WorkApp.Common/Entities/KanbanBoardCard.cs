using System.Collections.Generic;

namespace WorkApp.Common.Entities
{
    public class KanbanBoardCard : EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public virtual ICollection<KanbanBoardCardTag> Tags { get; set; }

    }
}
