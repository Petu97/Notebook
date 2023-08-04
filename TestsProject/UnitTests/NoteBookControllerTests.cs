using BusinessAndDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using NotebookApp.Controllers;
using TestsProject.TestMockups;

namespace TestsProject.UnitTests
{
    public class NoteBookControllerTests
    {
        //one could easily argue against creating test scenarios for controllers since they don't actually change data most of the time. 
        //these tests are implemented as am exercise

        #region GET_RetrunNotes

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

            var result = await controller.GET_Notes(); //act
            var resultObj = result as ObjectResult;
            var resultList = resultObj.Value as List<Note>;

            Assert.Equal(200, resultObj.StatusCode); //statuscode
            Assert.IsType<List<Note>>(resultList);
            Assert.Collection(resultList,
                item => Assert.Contains("Test1", item.Title),
                item => Assert.Contains("Test2", item.Title));

        }

        [Fact]
        public async Task GET_Notes_Returns404NotFound_EmptyListOfNotes()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            List<Note> notes = new List<Note>(); //seed datalogic response to controller
            mockup.response.Notes = notes;
            mockup.response.returnState = RequestReturnObject.ReturnState.NotFound;
            mockup.response.Notes = new List<Note>();

            var result = await controller.GET_Notes();
            var resultObj = result as ObjectResult;
            var resultList = resultObj.Value as List<Note>;

            Assert.Equal(404, resultObj.StatusCode);
            Assert.Empty(resultList);
        }

        [Fact]
        public async Task GET_Notes_Returns500InternalServerError_ErrorString()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); //arrange

            var result = await controller.GET_Notes();
            var resultObj = result as ObjectResult;
            var resultString = resultObj.Value as string;

            Assert.Equal(500, resultObj.StatusCode);
            Assert.Equal("Whoops we were unable to connect to an internal service, " +
                "please wait before trying again or call the company", resultString);
        }

        #endregion

        #region GET_FindNote

        //Note: finding notes happens on infrastrucure layer and passes it to controller, so
        //we'll be only testing out that the function returns a list of notes
        [Fact]
        public async Task GET_Note_Return200OK_ListOfNote() 
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup);

            List<Note> seedNotes = new List<Note>(); //seed datalogic response to controller
            Note note1 = new Note("Test1", "test contest", true);
            Note note2 = new Note("Test2", "", false);
            seedNotes.Add(note1);
            seedNotes.Add(note2);
            mockup.response.Notes = seedNotes;
            mockup.response.returnState = RequestReturnObject.ReturnState.Ok;
        }

        [Fact]
        public async Task GET_Note_Return500InternalServerError_ErrorString()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); 

        }

        #endregion

        #region POST_AddNote

        [Fact]
        public async Task POST_Note_Returns200OK_CreatedNote_WithOptionalParams()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); 
            mockup.response.returnState = RequestReturnObject.ReturnState.Ok;

            var result = await controller.POST_Note("Test book", "returns 200OK", true);
            var resultObj = result as ObjectResult;
            var resultNote = resultObj.Value as Note;

            Assert.Equal(200, resultObj.StatusCode); //check statuscode
            Assert.Equal("Test book", resultNote.Title); //check title
            Assert.Equal("returns 200OK", resultNote.Content); //check content
            Assert.True(resultNote.Completed); //check state
        }

        [Fact]
        public async Task POST_Note_Returns200OK_AddedNote_WithoutOptionalParams()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup); 
            mockup.response.returnState = RequestReturnObject.ReturnState.Ok;

            var result = await controller.POST_Note("Test book without params");
            var resultObj = result as ObjectResult;
            var resultNote = resultObj.Value as Note;

            Assert.Equal(200, resultObj.StatusCode);
            Assert.Equal("Test book without params", resultNote.Title);
            Assert.Equal("", resultNote.Content);
            Assert.False(resultNote.Completed);
        }

        [Fact]
        public async Task POST_Note_Returns500InternalServerError_InternalErrorObject()
        {
            Mockup_DataLogic mockup = new Mockup_DataLogic();
            var controller = new NoteBookController(mockup);

            var result = await controller.POST_Note("Test book for error");
            var resultObj = result as ObjectResult;
            var resultString = resultObj.Value as string;

            Assert.Equal(500, resultObj.StatusCode);
            Assert.Equal("Whoops we were unable to connect to an internal service, " +
                "please wait before trying again or call the company", resultString);
        }

        #endregion

        #region POST_ModifyNote
        #endregion

        #region DELETE_RemoveNote
        #endregion

    }
}