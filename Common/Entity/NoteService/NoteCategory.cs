﻿using System.ComponentModel.DataAnnotations;

namespace Common.Entity.NoteService
{
    public class NoteCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
