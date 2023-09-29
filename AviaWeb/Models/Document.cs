using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AviaWeb.Models
{
    public class Document
    {
        [Key]
        [Display(Name = "Номер")]
        public long Id { get; set; }
        
        [Display(Name = "Тип документа")]
        public string Type { get; set; }

        [Display(Name = "Код пассажира")]
        public long PassengerId { get; set; }

        [ForeignKey("PassengerId")]

        
        public Passenger Passenger { get; set; }
    }
}
