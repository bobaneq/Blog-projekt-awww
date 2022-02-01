using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class TagiController : Controller
    {
        // sending reciving data from db we need call dbcontext

        private readonly AppDbContext _context;

        public TagiController(AppDbContext context)
        {
            _context = context;
        }


        // async method
        public async Task<IActionResult> Index()
        {

            // zmiana sync methods to async 
            var WszystkieTagi = await _context.Tagi.ToListAsync();
            return View(WszystkieTagi);
        }
    }
}
