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
    }
}
