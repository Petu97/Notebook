using BusinessAndDataProject.DataLogic;
using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace NotebookApp.Controllers
{
    public class NoteBookController : Controller
    {
        private readonly IDataLogic dataLogic;

        public NoteBookController(IDataLogic _dataLogic)
        {
            dataLogic = _dataLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetNoteList() //return all notes
        {
            RequestReturnObject result = await dataLogic.ReturnNotes();

            return StatusCode(statusCode: (int)result.returnState, result.Notes);
        }

        [HttpGet]
        public async Task<IActionResult> GetNote([FromQuery ]int ?id, [FromQuery] string? title)
        {
            RequestReturnObject result = await dataLogic.ReturnNotes(); //implement query

            return StatusCode(statusCode: (int)result.returnState, result.Notes);
        }

        [HttpPost]
        public async Task<IActionResult> PostNote(JsonObject newItem)
        {
            Note newNote = new Note();

            RequestReturnObject result = await dataLogic.ReturnNotes(); //implement query

            return StatusCode(statusCode: (int)result.returnState, result.Notes);
        }

    }
}
