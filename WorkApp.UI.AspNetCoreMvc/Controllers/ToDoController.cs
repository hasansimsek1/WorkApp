using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.DTOs;
using WorkApp.Service.Interfaces;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Backs the todo module of the app.
    /// 
    /// <para/>
    /// Inherits from : 
    /// <see cref="BaseController"/>
    /// 
    /// <para/>
    /// Attributes : 
    /// <see cref="AuthorizeAttribute"/>
    /// 
    /// <para/>
    /// Actions : 
    /// <para/><see cref="Index"/> (Attributes : no attribute)
    /// <para/><see cref="Add"/>    (Attributes : HttpGet)
    /// <para/><see cref="Add(ToDoDto)"/>   (Attributes : HttpPost)
    /// 
    /// </summary>
    [Authorize]
    public class ToDoController : BaseController
    {
        private readonly IToDoService _toDoService;



        /// <summary>
        /// Constructor for getting dependency injection. Dependencies : <see cref="IToDoService"/>
        /// </summary>
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }




        /// <summary>
        /// Gets the user's todo records from service layer asynchronously and sends them to the view to be listed.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var toDoListResult = await _toDoService.GetToDoesOfUserAsync(userId);

            if (toDoListResult.HasError)
            {
                return RedirectToError();
            }
            else
            {
                return View(toDoListResult.Data);
            }
        }





        /// <summary>
        /// Just returns the view to the client.
        /// <para/>
        /// Attributes : HttpGet
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }





        /// <summary>
        /// Gets the todo model from the UI via <see cref="ToDoDto"/> model, adds UserId to the model, sends the model to service layer to be added. Then redirects the request to /ToDo/Index.
        /// <para/>
        /// Attributes : HttpPost
        /// </summary>
        /// <param name="model">Incoming model that carries new todo related information from the UI.</param>
        [HttpPost]
        public async Task<IActionResult> Add(ToDoDto model)
        {
            if(ModelState.IsValid)
            {
                model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); ;

                var result = await _toDoService.AddAsync(model);

                if(result.HasError)
                {
                    return RedirectToError();
                }

                return RedirectToAction("Index", "ToDo");
            }

            return View(model);
        }
    }
}