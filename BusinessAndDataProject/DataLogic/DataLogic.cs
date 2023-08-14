using BusinessAndDataProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BusinessAndDataProject.DataLogic
{
    public class DataLogic : IDataLogic
    {

        private readonly NoteBookDbContext DbContext;

        public DataLogic(NoteBookDbContext context)
        {
            DbContext = context;
        }

        public async Task <RequestReturnObject> AddNote(Note note)
        { 
            try
            {
                var queryResult = DbContext.Notes.Add(note); 
                await DbContext.SaveChangesAsync(); 

                if (queryResult is not null)
                    return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.Ok, 
                        _note: note);

                else //is this even running ever?
                    return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.BadRequest,
                        _note: note);
            }
            catch //failed to connect to database
            {
                return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.InternalServerError, 
                    _responseString: "Failed to connect to db");
            }
        }

        public async Task<RequestReturnObject> FindNote(int? id, string? title)
        {
            try
            {
                List<Note> queryResult = await DbContext.Notes.Where(x => id.HasValue ? x.Id == id : true).ToListAsync();
                queryResult = queryResult.Where(x => string.IsNullOrEmpty(title) ? x.Title.Contains(title) : true).ToList();

                if (queryResult.Any()) //return 
                    return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.Ok,
                        _notes: queryResult);
                else
                    return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.NotFound,
                        _notes: queryResult);
            }
            catch
            {
                return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.InternalServerError,
                    _responseString: "Failed to connect to db");
            }
        }

        public async Task<RequestReturnObject> ReturnNotes()
        {
            throw new NotImplementedException();
        }

        public async Task<RequestReturnObject> UpdateNote(int NoteID , Note updatedNote)
        {
            try
            {
                if (await DbContext.Notes.FindAsync(NoteID) is Note unchangedNote)
                {
                    DbContext.Entry(unchangedNote).CurrentValues.SetValues(updatedNote);
                    await DbContext.SaveChangesAsync();
                    return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.Ok,
                        _note: updatedNote); // maybe should fetch the updated note and return it
                }
                else
                    return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.BadRequest,
                        _note: updatedNote);

            }
            catch
            {
                return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.InternalServerError,
                    _note: updatedNote);
            }
        }

        public async Task<RequestReturnObject> DeleteNote(int id)
        {
            try
            {
                var note = await DbContext.Notes.FindAsync(id);
                DbContext.Notes.Remove(note);
                DbContext.SaveChangesAsync();

                return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.Ok,
                    _note: note);
            }
            catch
            {
                return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.InternalServerError,
                    _responseString: "Could not delete item");
            }
        }
    }
}
