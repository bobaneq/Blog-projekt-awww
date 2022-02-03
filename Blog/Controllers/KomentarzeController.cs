using Blog.Data;
using Blog.Data.Services;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class KomentarzeController : Controller
    {
        private readonly IKomentarzeService _service;

        public KomentarzeController(IKomentarzeService service)
        {
            _service = service;
        }


        // async method
        public async Task<IActionResult> Index()
        {

            // zmiana sync methods to async 
            var WszystkieKomentarze = await _service.GetAllAsync();
            return View(WszystkieKomentarze);
        }


        //GET: Komentarze/Create

        public IActionResult Create()
        {

            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Tresc")]Komentarz komentarz)
        {
            if (!ModelState.IsValid) View(komentarz);
            await _service.AddAsync(komentarz);
            return RedirectToAction(nameof(Index));

        }

    }
}
