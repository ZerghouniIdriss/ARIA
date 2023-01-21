using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Employee 
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<TimeSheet> TimeSheets { get; set; }

        /**HR**/
        public string Title { get; set; }
        public double Rate { get; set; }
        public double FedTax { get; set; }
        public double ProvTax { get; set; }
        public double RRQ { get; set; }
        public double RQAP { get; set; }
        public double Vacation { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

    }
}
