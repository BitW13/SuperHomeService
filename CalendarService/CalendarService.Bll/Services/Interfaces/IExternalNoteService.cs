using Common.Entity.NoteService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalendarService.Bll.Services.Interfaces
{
    public interface IExternalNoteService
    {
        Task<IEnumerable<Note>> GetNotesByDay(int day, int month, int year);

        Task<IEnumerable<Note>> GetNotesByMonth(int month, int year);

        Task<IEnumerable<Note>> GetNotesByYear(int year);
    }
}
