﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NotesService.WebApi.Models
{
    public class CreateNote
    {
        public string Name { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime LastChange { get; set; }

        [Required]
        public int NoteCategoryId { get; set; }
    }
}