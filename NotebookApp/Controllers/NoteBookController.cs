using BusinessAndDataProject.DataLogic;
using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace NotebookApp.Controllers
{
    [ApiController]
    [Route("note")]
    public class NoteBookController : Controller
    {
        //improvement idea: updated error handler as middleware. Clarifies controller and datalogic

        private readonly IDataLogic dataLogic;

        private RequestReturnObject internalFailureResponse = new RequestReturnObject(
            _returnstate: RequestReturnObject.ReturnState.InternalServerError,
            _responseString: "Whoops we were unable to connect to an internal service, please wait before trying again or call the company");

        public NoteBookController(IDataLogic _dataLogic)
        {
            dataLogic = _dataLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GET_Notes(int ?id, string? title)
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

            if (!TryValidateModel(newNote)) //validate model before trying to add it ro db
                return StatusCode(statusCode: 400, value: "Oops failed to create a note, please make sure your input follows the given rules");

            RequestReturnObject ?result = await dataLogic.AddNote(newNote);

            return result is null
                ? (IActionResult)StatusCode(statusCode: (int)internalFailureResponse.returnState, value: internalFailureResponse.ResponseString)
                : StatusCode(statusCode: (int)result.returnState, value: result.Note);
        }

        [HttpGet]
        public async Task<IActionResult> GET_UpdateNote(int NoteId, string title, string content = "", bool completed = false)
        {
            Note newNote = new Note(title, content, completed);

            if (!TryValidateModel(newNote)) //validate model before trying to add it ro db
                return StatusCode(statusCode: 400, value: "Oops failed to create a note, please make sure your input follows the given rules");

            RequestReturnObject? result = await dataLogic.UpdateNote(NoteId, newNote);

            return result is null
                ? (IActionResult)StatusCode(statusCode: (int)internalFailureResponse.returnState, value: internalFailureResponse.ResponseString)
                : StatusCode(statusCode: (int)result.returnState, value: result.Note);
        }

        [HttpGet]
        public async Task<IActionResult> GET_DeleteNote(int id)
        {
            RequestReturnObject? result = await dataLogic.DeleteNote(id);

            return result is null
                ? (IActionResult)StatusCode(statusCode: (int)internalFailureResponse.returnState, value: internalFailureResponse.ResponseString)
                : StatusCode(statusCode: (int)result.returnState, value: result.Note);
        }

    }
}
