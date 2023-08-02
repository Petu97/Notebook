using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using NotebookApp.Controllers;
using TestsProject.TestMockups;

namespace TestsProject.UnitTests
{
    public class NoteBookControllerTests
    {
        #region GET_GetNoteList

        [Fact]
        public async Task GET_Notes_Returns200OK_ListOfNotes()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            List<Note> seedNotes = new List<Note>(); //seed datalogic response to controller
            Note note1 = new Note("Test1", "test contest", true);
            Note note2 = new Note("Test2", "", false);
            seedNotes.Add(note1);
            seedNotes.Add(note2);
            mockup.response.Notes = seedNotes;
            mockup.response.returnState = RequestReturnObject.ReturnState.Ok;

            IActionResult result = await controller.GET_Notes(); //act

            ObjectResult objRes = Assert.IsType<ObjectResult>(result);  //assert
            Assert.Equal(200, objRes.StatusCode); //statuscode

            Assert.IsType<List<Note>>(objRes.Value); //object type
            //List<Note> returnedList = (List<Note>) objRes.Value;
           // Assert.Equal<Note>(seedNotes, objRes.Value);
        }

        [Fact]
        public async Task GET_Notes_Returns404NotFound_EmptyListOfNotes()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            List<Note> notes = new List<Note>(); //seed datalogic response to controller
            mockup.response.Notes = notes;
            mockup.response.returnState = RequestReturnObject.ReturnState.NotFound;

            IActionResult result = await controller.GET_Notes();

            ObjectResult objRes = Assert.IsType<ObjectResult>(result);
            Assert.IsType<string>(objRes.Value);
            Assert.Equal(404, objRes.StatusCode);
        }

        [Fact]
        public async Task GET_Notes_Returns500InternalServerError_ErrorString()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            IActionResult result = await controller.GET_Notes();

            ObjectResult objRes = Assert.IsType<ObjectResult>(result);
            Assert.IsType<string>(objRes.Value);
            Assert.Equal(500, objRes.StatusCode);
        }

        #endregion

        #region GET_GetNote

        //[Fact]
        //public async Task GET_Note_Return200OK_Note()
        //{
        //    var controller = new NoteBookController();
        //}

        //[Fact]
        //public async Task GET_Note_Return404NotFound_NoItemsFoundString()
        //{
        //    var controller = new NoteBookController();

        //}

        //[Fact]
        //public async Task GET_Note_Return500InternalServerError_ErrorString()
        //{
        //    var controller = new NoteBookController();

        //}
        #endregion

        #region POST_AddNote

        [Fact]
        public async Task POST_Note_Returns200OK_AddedNote_WithOptionalParams()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange
            mockup.response.returnState = RequestReturnObject.ReturnState.Ok;

            var result = await controller.POST_Note("Test book", "returns 200OK", true);

            //ObjectResult objRes = Assert.IsType<ObjectResult>(result);

            var returnedStatus = result as ObjectResult;
            var returnedNote = returnedStatus.Value as Note;

            Assert.Equal(200, returnedStatus.StatusCode); //statuscode is ok

             //assert created object into params
            Assert.Equal("Test book", returnedNote.Title);
            Assert.Equal("returns 200OK", returnedNote.Content);
            Assert.True(returnedNote.Completed);
        }

        [Fact]
        public async Task POST_Note_Returns200OK_AddedNote_WithoutOptionalParams()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            IActionResult result = await controller.POST_Note("Test book without params");

            ObjectResult objRes = Assert.IsType<ObjectResult>(result);
            //Assert.IsType<string>(objRes.Value);
            Assert.Equal(200, objRes.StatusCode);

            var note = Assert.IsType<Note>(objRes.Value); //assert created object into params
            Assert.Equal("Test book without params", note.Title);
            Assert.Equal("", note.Content);
            Assert.False(note.Completed);

        }

        #endregion

        #region POST_ModifyNote
        #endregion

        #region DELETE_RemoveNote
        #endregion

    }
}