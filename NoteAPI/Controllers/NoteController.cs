using NoteAPI.Models.DAO;
using NoteAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NoteAPI.Controllers
{
    public class NoteController : ApiController
    {
        [Route("Api/NoteController/GetAllNote")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllNote()
        {
            return Ok(await NoteDAO.Instance.GetAllNote());
        }


        [Route("Api/NoteController/AddNote")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> AddNote(NoteDTO noteDTO)
        {
            return Ok(await NoteDAO.Instance.AddNote(noteDTO));
        }

        [Route("Api/NoteController/UpdateNote")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> UpdateBrand(NoteDTO noteDTO)
        {
            return Ok(await NoteDAO.Instance.UpdateNote(noteDTO));
        }

        [Route("Api/NoteController/DeleteNote/{ID}")]
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBrand(int ID)
        {
            return Ok(await NoteDAO.Instance.DeleteNote(ID));
        }
    }
}
