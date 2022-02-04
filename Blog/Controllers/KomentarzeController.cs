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

        // trzeba poprawić komentarz bo bind nie działa z wpisem
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Tresc")]Komentarz komentarz)
        {
            if (!ModelState.IsValid) return View(komentarz);
            await _service.AddAsync(komentarz);
            return RedirectToAction(nameof(Index));

        }

        //GET Komentarze/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var komentarzeDetails = await _service.GetByIdAsync(id);

            if (komentarzeDetails == null) return View("NotFound");
            return View(komentarzeDetails);

        }

        //:GET Komentarze/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var komentarzeDetails = await _service.GetByIdAsync(id);

            if (komentarzeDetails == null) return View("NotFound");
            return View(komentarzeDetails);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Tresc")] Komentarz komentarz)
        {
            if (!ModelState.IsValid) return View(komentarz);
            await _service.UpdateAsync(id,komentarz);
            return RedirectToAction(nameof(Index));

        }

        //:GET Komentarze/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var komentarzeDetails = await _service.GetByIdAsync(id);

            if (komentarzeDetails == null) return View("NotFound");
            return View(komentarzeDetails);

        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var komentarzeDetails = await _service.GetByIdAsync(id);

            if (komentarzeDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
