using BusinessAndDataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
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
            RequestReturnObject returnObject;

            try
            {
                var queryResult = DbContext.Notes.Add(note); //returns entityentry type
                await DbContext.SaveChangesAsync(); //returns the number of entries added
                if (queryResult is not null)
                {
                    RequestReturnObject responseObject = new RequestReturnObject(_note: note, 
                        _returnstate: RequestReturnObject.ReturnState.Ok, _responseString: "Added note successfully!");
                    return responseObject;
                }
                else
                {
                    RequestReturnObject responseObject = new RequestReturnObject(_note: note, 
                        _returnstate: RequestReturnObject.ReturnState.BadRequest, _responseString: "Failed to add note to database");
                    return responseObject;
                }
            }
            catch //failed to connect to database
            {
                RequestReturnObject responseObject = new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.InternalServerError, _responseString: "Failed to connect to db");
                return responseObject;
            }
        }

        public async Task<RequestReturnObject> FindNote(int? id, string? title)
        {
            try
            {
                List<Note>? queryResult = DbContext.Notes.Find(id, title);

                if (queryResult is null)
                    return new RequestReturnObject(_returnstate: RequestReturnObject.ReturnState.InternalServerError,
                        _responseString: "Failed to fetch data from database");

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

        public async Task<RequestReturnObject> UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }



        //    public RequestReturnObject DataLogicGetNote(int id)
        //    {
        //        string responseString;
        //        Note? queryResponse;

        //        try
        //        {
        //            if (queryResponse is not null)
        //            {
        //                RequestReturnObject responseObject = new RequestReturnObject(null, queryResponse, _returnstate: RequestReturnObject.ReturnState.Ok, null);
        //                return responseObject;
        //            }

        //            else
        //            {
        //                responseString = "No items found";
        //                RequestReturnObject requestReturnObject = new RequestReturnObject(null, null, _returnstate: RequestReturnObject.ReturnState.NotFound, responseString);
        //                return requestReturnObject;
        //            }
        //        }

        //        catch
        //        {
        //            responseString = "Serverside error";
        //            RequestReturnObject requestReturnObject = new RequestReturnObject(null, null, _returnstate: RequestReturnObject.ReturnState.InternalServerError, responseString);
        //            return requestReturnObject;
        //        }

        //    }

    }
}
