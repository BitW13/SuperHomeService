﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NotesService.Models
{
    public class NewNote
    {
        public string Name { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime LastChange { get; set; }

        [Required]
        public int NoteCategoryId { get; set; }
    }
}
