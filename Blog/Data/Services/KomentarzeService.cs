using Blog.Data.Base;
using Blog.Models;

namespace Blog.Data.Services
{
    public class KomentarzeService: EntityBaseRepository<Komentarz>, IKomentarzeService
    {
        public KomentarzeService(AppDbContext context):base(context)
        {

        }
            

    }
}
