using NoteAPI.Models.DTO;
using NoteAPI.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NoteAPI.Models.DAO
{
    public class NoteDAO
    {
        private static NoteDAO instance;

        public static NoteDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NoteDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        notedbEntities db = new notedbEntities();

        public async Task<List<NoteDTO>> GetAllNote()
        {
            var noteList = (await db.Notes
                        .ToListAsync())
                        .Select(note => new NoteDTO(note))
                        .ToList();
            return noteList;
        }

        public async Task<int> AddNote(NoteDTO noteDTO)
        {
            var note = new Note()
            {
                Title = noteDTO.Title,
                Content = noteDTO.Content,
            };

            try
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
                return note.ID;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        public async Task<bool> UpdateNote(NoteDTO noteDTO)
        {
            var result = db.Notes.SingleOrDefault(b => b.ID == noteDTO.Id);
            try
            {
                result.Title = noteDTO.Title;
                result.Content = noteDTO.Content;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public async Task<bool> DeleteNote(int ID)
        {
            var result = db.Notes.SingleOrDefault(b => b.ID == ID);

            try
            {
                db.Notes.Remove(result);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
    }
}