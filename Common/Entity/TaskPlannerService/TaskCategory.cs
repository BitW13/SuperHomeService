﻿using System.ComponentModel.DataAnnotations;

namespace Common.Entity.TaskPlannerService
{
    public class TaskCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public bool IsOn { get; set; }
    }
}
