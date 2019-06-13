using AutoMapper;
using Common.Entity.NoteService;
using NotesService.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
