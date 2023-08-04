using BusinessAndDataProject.DataLogic;
using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace NotebookApp.Controllers
{
    public class NoteBookController : Controller
    {
        private readonly IDataLogic dataLogic;

        private RequestReturnObject internalFailureResponse = new RequestReturnObject(
            _returnstate: RequestReturnObject.ReturnState.InternalServerError,
            _responseString: "Whoops we were unable to connect to an internal service, please wait before trying again or call the company");

        public NoteBookController(IDataLogic _dataLogic)
        {
            dataLogic = _dataLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GET_Notes() //this function is actually obselite, need only the one under
        {
            RequestReturnObject ?result = await dataLogic.ReturnNotes();

            return result is null
                ? (IActionResult)StatusCode(statusCode: (int)internalFailureResponse.returnState, value: internalFailureResponse.ResponseString) //null response (failed to connect to logic layer)
                : StatusCode(statusCode: (int)result.returnState, value: result.Notes); //successfull response (successfully received a response from logic layer)
        }

        [HttpGet]
        public async Task<IActionResult> GET_Note(int ?id, string? title)
        {
            RequestReturnObject ?result = await dataLogic.FindNote(id, title);

            return result is null
                ? (IActionResult)StatusCode(statusCode: (int)internalFailureResponse.returnState, value: internalFailureResponse.ResponseString)
                : StatusCode(statusCode: (int)result.returnState, value: result.Notes);
        }

        [HttpPost]
        public async Task<IActionResult> POST_Note(string title, string content="", bool completed=false)
        {
            Note newNote = new Note(title, content, completed);

            RequestReturnObject ?result = await dataLogic.AddNote(newNote);

            return result is null
                ? (IActionResult)StatusCode(statusCode: (int)internalFailureResponse.returnState, value: internalFailureResponse.ResponseString)
                : StatusCode(statusCode: (int)result.returnState, value: result.Note);
        }

    }
}
