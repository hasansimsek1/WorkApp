using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Service.Interfaces;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Controller that backs kanban board related views.
    /// It serves the logic related to kanban board pages.
    /// 
    /// <para/>
    /// 
    /// Inherits from : 
    /// <see cref="BaseController"/>
    /// 
    /// <para/>
    /// 
    /// Attributes : 
    /// <see cref="AuthorizeAttribute"/>
    /// 
    /// <para/>
    /// 
    /// Actions : 
    /// <para/><see cref="Index"/> (Attribute : [HttpGet] )
    /// <para/><see cref="Add"/> (Attribute : [HttpGet] )
    /// <para/><see cref="Add(KanbanBoardDto)"/> Attribute : [HttpPost] )
    /// <para/><see cref="Board(int)"/>  (Attribute : [HttpGet] )
    /// <para/>
    /// 
    /// </summary>
    [Authorize]
    public class KanbanBoardController : BaseController
    {
        private readonly IKanbanBoardService _kanbanService;


        /// <summary>
        /// Constructor for getting dependency injection. Dependencies : <see cref="IKanbanBoardService"/>
        /// </summary>
        public KanbanBoardController(IKanbanBoardService kanbanService)
        {
            _kanbanService = kanbanService;
        }



        /// <summary>
        /// Gets all kanban board records that belong to the user from service layer asynchronously and sends the data to the Index view.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _kanbanService.GetAllAsync(userId);

            if (result.HasError)
            {
                return RedirectToError();
            }
            
            return View(result.Data);
        }



        /// <summary>
        /// Just returns the Add view to the client.
        /// <para/>
        /// Attributes : HttpGet
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



        /// <summary>
        /// Gets the data from the user via <see cref="KanbanBoardDto"/> viewmodel, 
        /// validates the incoming model, 
        /// adds UserId to the model, 
        /// sends the data to service layer to be added,
        /// redirects the request to the /KanbanBoard/Index.
        /// If error occures while adding new kanban board to the database, adds the error to the ModelState and returns the view again.
        /// 
        /// <para/>
        /// Attributes : HttpPost
        /// 
        /// </summary>
        /// <param name="model">Model for new kanban board.</param>
        [HttpPost]
        public async Task<IActionResult> Add(KanbanBoardDto model)
        {
            if(ModelState.IsValid)
            {
                model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var result = await _kanbanService.AddAsync(model);

                if(result.HasError)
                {
                    return RedirectToError();
                }
                else
                {
                    return RedirectToAction("Index", "KanbanBoard");
                }
            }

            return View(model);
        }



        /// <summary>
        /// Gets the kanban board details from service layer asynchronously and sends the data to the view.
        /// <para/>
        /// Attributes : HttpGet
        /// </summary>
        /// <param name="id">Id of the kanban board.</param>
        [HttpGet]
        public async Task<IActionResult> Board(int id)
        {
            var result = await _kanbanService.GetByIdAsync(id);

            if (result.HasError)
            {
                return RedirectToError();
            }

            // temporary code
            ViewBag.KanbanId = id;

            return View(result.Data);
        }
    }
}