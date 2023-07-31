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

            //List<Note> notes = new List<Note>();
            //Note note1 = new Note();
            //Note note2 = new Note();
            //notes.Add(note1);
            //notes.Add(note2);

            IActionResult result = await controller.GET_Notes(); //act

            ObjectResult objRes = Assert.IsType<OkObjectResult>(result);  //assert
            Assert.IsType<List<Note>>(objRes.Value); //object type
            Assert.Equal(200, objRes.StatusCode); //statuscode
        }

        [Fact]
        public async Task GET_Notes_Returns404NotFound_EmptyListOfNotes()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            IActionResult result = await controller.GET_Notes();

            ObjectResult objRes = Assert.IsType<NotFoundObjectResult>(result);
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

            IActionResult result = await controller.POST_Note("Test book", "return 200OK", false);

            ObjectResult objRes = Assert.IsType<ObjectResult>(result);
            Assert.IsType<string>(objRes.Value);
            Assert.Equal(200, objRes.StatusCode);

        //assert created object into params
        }

        [Fact]
        public async Task POST_Note_Returns200OK_AddedNote_WithoutOptionalParams()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            IActionResult result = await controller.POST_Note("Test book without params");

            ObjectResult objRes = Assert.IsType<ObjectResult>(result);
            Assert.IsType<string>(objRes.Value);
            Assert.Equal(200, objRes.StatusCode);
        }

        #endregion

        #region POST_ModifyNote
        #endregion

        #region DELETE_RemoveNote
        #endregion

    }
}