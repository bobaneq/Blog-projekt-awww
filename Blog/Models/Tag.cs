using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nazwa Tagu")]
        public string Nazwa { get; set; }
        public List<TagWpis> TagiWpisy { get; set; }


        //public int WpisId { get; set; }
        //public Wpis Wpis { get; set; }



    }
}
