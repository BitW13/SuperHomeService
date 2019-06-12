using System;
using System.ComponentModel.DataAnnotations;

namespace NotesService.WebApi.Models
{
    public class EditNote
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime LastChange { get; set; }

        [Required]
        public int NoteCategoryId { get; set; }
    }
}
