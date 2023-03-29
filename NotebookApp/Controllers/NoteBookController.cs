using Microsoft.AspNetCore.Mvc;

namespace NotebookApp.Controllers
{
    public class NoteBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
