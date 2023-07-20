using BusinessAndDataProject.DataLogic;
using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GET_Notes() 
        {
            RequestReturnObject result = await dataLogic.ReturnNotes();

            return StatusCode(statusCode: (int)result.returnState, result.Notes);
        }

        [HttpGet]
        public async Task<IActionResult> GET_Note(int ?id, string? title)
        {
            RequestReturnObject result = await dataLogic.FindNote(id, title); 

            return StatusCode(statusCode: (int)result.returnState, result.Notes);
        }

        [HttpPost]
        public async Task<IActionResult> POST_Note(string title, string content, bool completed)
        {
            Note newNote = new Note(title, content, completed);

            RequestReturnObject result = await dataLogic.AddNote(newNote); 

            return StatusCode(statusCode: (int)result.returnState, result.Notes);
        }

    }
}
