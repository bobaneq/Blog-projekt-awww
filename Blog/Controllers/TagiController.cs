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




        public async Task<IActionResult> Index()
        {
            var WszystkieTagi = await _service.GetAllAsync();
            return View(WszystkieTagi);


        }

        //To jest Get request : Tagi/Create
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nazwa")] Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }
            await _service.AddAsync(tag);
            return RedirectToAction(nameof(Index));

        }


        //Get: Tagi/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var tagiDetails =await _service.GetByIdAsync(id);

        if (tagiDetails == null) return View("NotFound");
        return View(tagiDetails);
        
        }


        //To jest Get request : Tagi/Create
        public async Task<IActionResult> Edit(int id)
        {

            var tagiDetails = await _service.GetByIdAsync(id);

            if (tagiDetails == null) return View("NotFound");

            return View(tagiDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }
            await _service.UpdateAsync(id,tag);
            return RedirectToAction(nameof(Index));

        }




    }
}
