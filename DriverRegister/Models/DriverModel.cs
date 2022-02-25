using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DriverRegister.Models
{
    public class DriverModel
    {
        public int IdKierowcy { get; set; }
        [DisplayName("Imię")]
        [Required]
        public string Imie { get; set; }
        [Required]
        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }
        [Required]
        [DisplayName("Pesel")]
        public string Pesel { get; set; }
        [Required]
        [DisplayName("Numer lini")]
        public int NumerLini { get; set; }
    }
}