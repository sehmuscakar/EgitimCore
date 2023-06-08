using System.ComponentModel.DataAnnotations;

namespace Giriş.Models
{
    public class Urun
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad Boş Geçilemez!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
