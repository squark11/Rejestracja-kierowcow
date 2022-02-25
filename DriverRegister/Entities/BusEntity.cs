using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DriverRegister.Entities
{
    public class BusEntity
    {
        [Key]
        public int IdBus { get; set; }
        [DisplayName("Numer lini")]
        public int NumerLini { get; set; }
        [DisplayName("Zdjęcie")]
        public string PhotoURL { get; set; }
    }
}