using Blog.Data;
using Blog.Data.Services;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class TagiController : Controller
    {
        // sending reciving data from db we need call dbcontext
        // tutaj przeniesiem to injection do TagiService
        private readonly ITagiService _service;

        public TagiController(ITagiService service)
        {

            _service = service;
        }


        //To jest Get request : Actors/Create

        public async Task<IActionResult> Index()
        {
            var WszystkieTagi =await _service.GetAll();
            return View(WszystkieTagi);


        }






    }
}
