using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap başlığı zorunludur")]
        [MaxLength(200, ErrorMessage = "Kitap başlığı en fazla 200 karakter olabilir")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Range(0.01, 99999, ErrorMessage = "Fiyat 0'dan büyük olmalıdır")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
