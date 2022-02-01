using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class TagWpis
    {

        public int WpisId { get; set; }

        public Wpis Wpis { get; set; }

        public int TagId { get; set; }

        
        public Tag Tag { get; set; }    


    }
}
