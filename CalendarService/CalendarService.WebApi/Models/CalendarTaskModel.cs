using Common.Entity.CalendarService;
using System.ComponentModel.DataAnnotations;

namespace CalendarService.WebApi.Models
{
    public class CalendarTaskModel
    {
        [Required]
        public CalendarTask Task { get; set; }

        [Required]
        public CalendarTaskCategory TaskCategory { get; set; }
    }
}