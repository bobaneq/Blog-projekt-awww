using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nazwa tagu jest wymagana")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Tag musi mieć między 3 a 20 znaków")]
        [Display(Name ="Nazwa Tagu")]
        public string Nazwa { get; set; }
        public List<TagWpis> TagiWpisy { get; set; }


        //public int WpisId { get; set; }
        //public Wpis Wpis { get; set; }



    }
}
