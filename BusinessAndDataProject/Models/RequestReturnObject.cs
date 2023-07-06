using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAndDataProject.Models
{
    public class RequestReturnObject
    {
        public List<Note> ?Notes;

        public Note ?Note;

        public string ?ResponseString;

        public ReturnState returnState;
        public enum ReturnState
        {
            DefaultValue = 0,
            Ok = 200,
            BadRequest = 400,
            NotFound = 404,
            InternalServerError = 500,
        }

        public RequestReturnObject(List<Note> ?_notes = null, Note ?_note = null, ReturnState _returnstate = ReturnState.DefaultValue, string ?_responseString = null)
        {
            Notes = _notes;
            Note = _note;
            returnState = _returnstate;
            ResponseString = _responseString;
        }
    }
}
