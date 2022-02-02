using Blog.Data;
using Blog.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class TagiController : Controller
    {
        // sending reciving data from db we need call dbcontext

        private readonly ITagsService _service;

        public TagiController(ITagsService service)
        {
            _service = service;
        }


        // async method
        public async Task<IActionResult> Index()
        {

            // zmiana sync methods to async 
            var WszystkieTagi = await _service.GetAll();
            return View(WszystkieTagi);
        }
    }
}
