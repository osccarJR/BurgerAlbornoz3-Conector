using BurgerAlbornoz3.Models;
using System.ComponentModel.DataAnnotations;

namespace BurgerAlbornoz3.Models
{
    public class Promo
    {
        [Key]
        public int PromId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaPromo { get; set; }

        public int BurgerID { get; set; }
        public Burger? Burger { get; set; }
    }
}
