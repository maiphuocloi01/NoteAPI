﻿using NoteAPI.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteAPI.Models.DTO
{
    public class NoteDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public NoteDTO()
        {

        }

        public NoteDTO(Note note)
        {
            Id = note.ID;
            Title = note.Title;
            Content = note.Content;
        }

    }
}