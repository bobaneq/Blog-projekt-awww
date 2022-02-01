using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Komentarz
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Treść komentarza")]
        public string Tresc { get; set; }

        public int WpisId { get; set; }
        
        [ForeignKey("WpisId")]
        public Wpis Wpis { get; set; }


    }
}
