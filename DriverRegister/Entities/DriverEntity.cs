using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DriverRegister.Entities
{
    public class DriverEntity
    {
        [Key]
        public int IdKierowcy { get; set; }
        [DisplayName("Imię")]
        public string Imie { get; set; }
        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }
        [DisplayName("Pesel")]
        public string Pesel { get; set; }
        [DisplayName("Numer lini")]
        public int NumerLini { get; set; }
    }
}