using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace NotebookApp.Controllers
{
    public class NoteBookController : Controller
    {

        public async Task<IActionResult> GetNoteList(List<Note> ?res) //return all notes
        {
            var result = res; //add async function for finding notes in database

            if (result is null)
                return StatusCode(statusCode: 500,"Failed to connect to database");

            else if (!result.Any())
                return NotFound("You don't have any notes");

            else
                return Ok(result);   
        }
    }
}
