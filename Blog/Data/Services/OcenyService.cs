using Blog.Data.Base;
using Blog.Models;

namespace Blog.Data.Services
{
    public class OcenyService:EntityBaseRepository<Ocena>,IOcenyService
    {

        public OcenyService(AppDbContext context):base(context)
        {

        }

    }
}
