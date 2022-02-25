using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DriverRegister.Models
{
    public class BusModel
    {
        public int Id { get; set; }
        
        [DisplayName("Numer lini")] 
        [Required]
        public int NumerLini { get; set; }
        [Required]
        [DisplayName("Zdjęcie")]
        public string PhotoURL { get; set; }
    }
}