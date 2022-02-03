using Blog.Data;
using Blog.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class WpisyController : Controller
    {
        private readonly IWpisyService _service;

        public WpisyController(IWpisyService service)
        {
            _service = service;
        }



        // async method
        public async Task<IActionResult> Index()
        {

            // zmiana sync methods to async   tutaj trzeba sprawdzic komentarz i komentarze
            var WszystkieWpisy = await _service.GetAllAsync(n => n.Komentarze);
            return View(WszystkieWpisy);
        }

        //GET: Wpisy/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var wpisDetails = await _service.GetWpisByIdAsync(id);
            return View(wpisDetails);
        }

        //dodawanie nowych wpisów
        //GET Wpisy/Create

        public IActionResult Create()
        {
            ViewData["Dodaj"] = "Dodaj nowy wpis";

            ViewBag.Description = "This is the description";

            return View();

        }



    }
}



