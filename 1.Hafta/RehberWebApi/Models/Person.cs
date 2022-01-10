using System.ComponentModel.DataAnnotations;

namespace RehberWebApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad boş geçilemez!")]
        [StringLength(20, ErrorMessage = "Ad en fazla 20 karakter olabilir!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez!")]
        [StringLength(20, ErrorMessage = "Soyad en fazla 20 karakter olabilir!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telefon boş geçilemez!")]
        [StringLength(20, ErrorMessage = "Telefon en fazla 10 karakter olabilir!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Adres boş geçilemez!")]
        [StringLength(20, ErrorMessage = "Adres en fazla 300 karakter olabilir!")]
        public string Address { get; set; }
    }
}
