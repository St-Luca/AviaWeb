using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AviaWeb.Models
{
    public class Passenger
    {
        [Key]
        [Display(Name = "Номер")]
        public long Id { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronical { get; set; }
        public List<Document> Documents { get; set; }
       
        [Display(Name = "Билеты")]
        public List<AirTicket> AirTickets { get; set; }

        public Passenger()
        {
            Documents = new List<Document>();
            AirTickets = new List<AirTicket>();
        }
    }
}
