using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using NotebookApp.Controllers;

namespace TestsProject
{
    public class NoteBookControllerTests
    {
        #region GET_GetNoteList


        [Fact]
        public async Task Get_GetNoteList_Returns200OK_ListOfNotes()
        {
            var controller = new NoteBookController(); //arrange

            List<Note> notes = new List<Note>();
            Note note1 = new Note();
            Note note2 = new Note();
            notes.Add(note1);
            notes.Add(note2);

            IActionResult result = await controller.GetNoteList(notes); //act

            ObjectResult objRes = Assert.IsType<OkObjectResult>(result);  //assert
            Assert.IsType<List<Note>>(objRes.Value); //object type
            Assert.Equal(200, objRes.StatusCode); //statuscode
        }

        [Fact]
        public async Task Get_GetNoteList_Returns404NotFound_NoItemsFound()
        {
            var controller = new NoteBookController(); 

            List<Note> notes = new List<Note>();
            IActionResult result = await controller.GetNoteList(notes);

            ObjectResult objRes = Assert.IsType<NotFoundObjectResult>(result);  
            Assert.IsType<String>(objRes.Value);
            Assert.Equal(404, objRes.StatusCode);
        }

        [Fact]
        public async Task Get_GetNoteList_Returns500InternalServerError_ErrorString()
        {
            var controller = new NoteBookController(); 

            IActionResult result =await controller.GetNoteList(null); 

            ObjectResult objRes = Assert.IsType<ObjectResult>(result);  
            Assert.IsType<String>(objRes.Value);
            Assert.Equal(500, objRes.StatusCode);
        }

        #endregion

        #region GET_GetNote
        #endregion

        #region POST_AddNote
        #endregion

        #region POST_ModifyNote
        #endregion

        #region DELETE_RemoveNote
        #endregion

    }
}