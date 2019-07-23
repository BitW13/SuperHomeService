using System;
using System.ComponentModel.DataAnnotations;

namespace NotesService.WebApi.Models
{
    public class EditNote
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime LastChange { get; set; }

        public int NoteCategoryId { get; set; }
    }
}
