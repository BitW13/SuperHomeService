using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entity.NoteService
{
    public class Note
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime LastChange { get; set; }

        public int NoteCategoryId { get; set; }
    }
}
