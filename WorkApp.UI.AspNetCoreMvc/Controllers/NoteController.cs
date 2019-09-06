using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Service.Interfaces;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    public class NoteController : BaseController
    {
        private readonly INoteService _noteService;
        private readonly string _userId;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
            _userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<IActionResult> Index()
        {
            var result = await _noteService.GetAllAsync(_userId);

            if(result.HasError)
            {
                return RedirectToError();
            }
            else
            {
                return View(result.Data);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}