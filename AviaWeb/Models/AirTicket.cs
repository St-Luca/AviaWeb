using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AviaWeb.Models
{
    public class AirTicket
    {
        [Key]
        [Display(Name = "Номер")]
        public long Id { get; set; }
        [Display(Name = "Пункт отправления")]
        public string Departure { get; set; }
        [Display(Name = "Пункт назначения")]
        public string Arrival { get; set; }
        [Display(Name = "Дата заключения")]
        public DateTime DateOfConclusion { get; set; }
        [Display(Name = "Дата вылета")]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "Дата прилета")]
        public DateTime ArrivalDate { get; set; }
        [Display(Name = "Поставщик")]
        public string Company { get; set; }
        public long PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        [Display(Name = "Пассажир")]
        public Passenger Passenger { get; set; }

        public AirTicket()
        {
        }
    }
}
