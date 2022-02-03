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
    }
}



