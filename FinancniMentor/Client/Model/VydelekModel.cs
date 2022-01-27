using FinancniMentor.Shared;
using System.ComponentModel.DataAnnotations;

namespace FinancniMentor.Client.Model
{
    public class VydelekModel
    {
        [Required(ErrorMessage = "Vyplňte datum")]
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Vyplňte subjekt") ]
        [StringLength(100)]
        public string Subjekt { get; set; }
       
        [Required(ErrorMessage = "Vyplňte kategorii")]
        public VydelekKategorie Kategorie { get; set; }
        [Required(ErrorMessage = "Vyplňte částku")]
        public decimal Castka { get; set; }
    }
}
