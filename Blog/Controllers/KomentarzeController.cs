using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class KomentarzeController : Controller
    {
        private readonly AppDbContext _context;

        public KomentarzeController(AppDbContext context)
        {
            _context = context;
        }


        // async method
        public async Task<IActionResult> Index()
        {

            // zmiana sync methods to async 
            var WszystkieKomentarze = await _context.Komentarze.ToListAsync();
            return View(WszystkieKomentarze);
        }
    }
}
