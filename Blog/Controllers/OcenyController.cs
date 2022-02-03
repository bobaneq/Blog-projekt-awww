using Blog.Data;
using Blog.Data.Services;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class OcenyController : Controller
    {

        private readonly IOcenyService _service;

        public OcenyController(IOcenyService service)
        {
            _service = service;
        }


        // async method
        public  async Task<IActionResult> Index()
        {

            // zmiana sync methods to async 
            var WszystkieOceny = await _service.GetAllAsync();
            return View(WszystkieOceny);
        }

        // new ActionResult GET: Oceny/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var ocenyDetails = await _service.GetByIdAsync(id);
            if (ocenyDetails == null) return View("NotFound");
            return View(ocenyDetails);  
        }


        // GET Oceny/Create

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        // tutaj w bind nie będziemy podmieniać Id w bazie,
        // więc to jest do zmiany
        public async Task<IActionResult> Create([Bind("Id")]Ocena ocena)
        {
            if(!ModelState.IsValid)return View(ocena);
            await _service.AddAsync(ocena);

            return RedirectToAction(nameof(Index));


        }
        // GET Oceny/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var ocenyDetails = await _service.GetByIdAsync(id);
            if (ocenyDetails == null) return View("NotFound");
            return View(ocenyDetails);
        }
    

        [HttpPost]

        // tutaj w bind nie będziemy podmieniać Id w bazie,
        // więc to jest do zmiany
        public async Task<IActionResult> Edit(int id,[Bind("Id")] Ocena ocena)
        {
            if (!ModelState.IsValid) return View(ocena);
            
            
            if(id==ocena.Id)
                {
                await _service.UpdateAsync(id, ocena);
                return RedirectToAction(nameof(Index));


            }
            return View(ocena);


        }
        // GET Oceny/Delete

        public async Task<IActionResult> Delete(int id)
        {
            var ocenyDetails = await _service.GetByIdAsync(id);
            if (ocenyDetails == null) return View("NotFound");
            return View(ocenyDetails);
        }

        // dl użycia tej samej akcji muisimy podać nazwę akcji
        [HttpPost, ActionName("Delete")]

        // tutaj w bind nie będziemy podmieniać Id w bazie,
        // więc to jest do zmiany
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // sprawdzenie czy instnieje ocena
            var ocenyDetails = await _service.GetByIdAsync(id);
            if (ocenyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}

