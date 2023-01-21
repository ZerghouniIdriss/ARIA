namespace SPA.Models
{
    public class TimeSheetViewModel
    {
        
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public DateTime WeekDate { get; set; }
        public Day D0 { get; set; }
        public Day D1 { get; set; }
        public Day D2 { get; set; }
        public Day D3 { get; set; }
        public Day D4 { get; set; }
        public Day D5 { get; set; }
        public Day D6 { get; set; }

        public string Tasks { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        public double Total()
        {
            return this.D0.Total() + this.D1.Total() + this.D2.Total() + this.D3.Total() + this.D4.Total() + this.D5.Total() + this.D6.Total();
        }
    }

    public class Day
    {
        public double Regular { get; set; } 
        public double Overtime { get; set; }
        public double Vacation { get; set; }
        public double Holiday { get; set; } 

        public double Total()
        {
            return this.Regular + this.Overtime + this.Vacation + this.Holiday;
        }
    }

}
