﻿namespace WorkApp.Common.Entities
{
    public class NoteTag : EntityBase
    {
        public int NoteId { get; set; }
        public Note Note { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
