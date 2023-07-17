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
        Task<RequestReturnObject> AddItem(Note note);
        Task<RequestReturnObject> UpdateItem(Note note);
        Task<RequestReturnObject> ReturnNotes();
        Task<RequestReturnObject> ReturnNote(int ?id, string ?title);
    }
}
