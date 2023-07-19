using BusinessAndDataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAndDataProject.DataLogic
{
    public interface IDataLogic 
    {
        Task<RequestReturnObject> AddNote(Note note);
        Task<RequestReturnObject> UpdateNote(Note note);
        Task<RequestReturnObject> FindNote(int? id, string? title);
        Task<RequestReturnObject> ReturnNotes();

    }
}
