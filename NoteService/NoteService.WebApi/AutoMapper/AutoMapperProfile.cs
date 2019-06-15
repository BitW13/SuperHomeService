using AutoMapper;
using Common.Entity.NoteService;
using NotesService.WebApi.Models;

namespace NoteService.WebApi.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Note, EditNote>()
                .ReverseMap();
            CreateMap<Note, CreateNote>()
                .ReverseMap();
            CreateMap<NoteCategory, CreateNoteCategory>()
                .ReverseMap();
            CreateMap<NoteCategory, EditNoteCategory>()
                .ReverseMap();
        }
    }
}
