using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class OcenyController : Controller
    {

        private readonly AppDbContext _context;

        public OcenyController(AppDbContext context)
        {
            _context = context;
        }


        // async method
        public  async Task<IActionResult> Index()
        {

            // zmiana sync methods to async 
            var WszystkieOceny = await _context.Oceny.ToListAsync();
            return View(WszystkieOceny);
        }
    }
}
