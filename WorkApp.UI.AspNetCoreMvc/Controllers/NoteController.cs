﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Service.Interfaces;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Backs the note taking related views.
    /// 
    /// <para/>
    /// Inherits from : <see cref="BaseController"/>
    /// 
    /// <para/>
    /// Attributes : <see cref="AuthorizeAttribute"/>
    /// 
    /// <para/>
    /// Actions : 
    /// <para/><see cref="Index"/> (Attributes : no attribute)
    /// <para/><see cref="Add"/> (Attributes : HttpGet)
    /// 
    /// </summary>
    [Authorize]
    public class NoteController : BaseController
    {
        private readonly INoteService _noteService;

        /// <summary>
        /// Constructor for getting dependency injection. 
        /// Dependencies : <see cref="INoteService"/>
        /// </summary>
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        /// <summary>
        /// Retrieves the note records of the user from service layer asynchronously and sends them to the view to be listed.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _noteService.GetByUserId(userId);

            if(result.HasError)
            {
                return RedirectToError();
            }
            else
            {
                return View(result.Data);
            }
        }

        /// <summary>
        /// Returns the view that shows a WYSIWYG editor to the user.
        /// <para/>
        /// Attributes : HttpGet
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}