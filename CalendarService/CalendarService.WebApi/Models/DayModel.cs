using System;
using System.Collections.Generic;

namespace CalendarService.WebApi.Models
{
    public class DayModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        IEnumerable<CalendarTaskModel> Tasks { get; set; }
    }
}
