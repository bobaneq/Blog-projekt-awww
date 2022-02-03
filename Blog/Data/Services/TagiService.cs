using Blog.Data.Base;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Services
{
    public class TagiService : EntityBaseRepository<Tag>, ITagiService
    {
        public TagiService(AppDbContext context) : base(context) { }
 
    }
}
