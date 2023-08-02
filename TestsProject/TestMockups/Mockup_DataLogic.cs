using BusinessAndDataProject.DataLogic;
using BusinessAndDataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace TestsProject.TestMockups
{
    public class Mockup_DataLogic : IDataLogic
    {
        public RequestReturnObject response = new RequestReturnObject();
        public async Task<RequestReturnObject> ReturnNotes()
        {
            return response;
        }

        public async Task<RequestReturnObject> FindNote(int? id, string? title)
        {
            return response;
        }

        public async Task<RequestReturnObject> UpdateNote(Note note)
        {
            return response;
        }

        public async Task<RequestReturnObject> AddNote(Note note)
        {
            response.Note = note;
            return response;
        }

    }
}
