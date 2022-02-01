using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class WpisyController : Controller
    {
        private readonly AppDbContext _context;

        public WpisyController(AppDbContext context)
        {
            _context = context;
        }



        // async method
        public async Task<IActionResult> Index()
        {

            // zmiana sync methods to async 
            var WszystkieWpisy = await _context.Wpisy.OrderByDescending(o =>o.DataDodania).ToListAsync();
            return View(WszystkieWpisy);
        }
    }
}



