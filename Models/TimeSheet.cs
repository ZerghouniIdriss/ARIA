using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using SPA.Models;

namespace SPA.Models
{

    public class TimeSheet
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime WeekDate { get; set; }
        public double D0Regular { get; set; }
        public double D0Overtime { get; set; }
        public double D0Vacation { get; set; }
        public double D0Holiday { get; set; }
        public double D1Regular { get; set; }
        public double D1Overtime { get; set; }
        public double D1Vacation { get; set; }
        public double D1Holiday { get; set; }
        public double D2Regular { get; set; }
        public double D2Overtime { get; set; }
        public double D2Vacation { get; set; }
        public double D2Holiday { get; set; }
        public double D3Regular { get; set; }
        public double D3Overtime { get; set; }
        public double D3Vacation { get; set; }
        public double D3Holiday { get; set; }
        public double D4Regular { get; set; }
        public double D4Overtime { get; set; }
        public double D4Vacation { get; set; }
        public double D4Holiday { get; set; }
        public double D5Regular { get; set; }
        public double D5Overtime { get; set; }
        public double D5Vacation { get; set; }
        public double D5Holiday { get; set; }
        public double D6Regular { get; set; }
        public double D6Overtime { get; set; }
        public double D6Vacation { get; set; }
        public double D6Holiday{ get; set; }


        public string Tasks { get; set; }
        public string Comments { get; set; }

        public int Status { get; set; }

       

        [NotMapped]
        public DateTime WeekDateEnd
        {
            get { return WeekDate.AddDays(6); }
        }

        [NotMapped]
        public double TotalRegular
        {
            get { return D0Regular + D1Regular + D2Regular + D3Regular + D4Regular + D5Regular + D6Regular; }
        }

        [NotMapped]
        public double TotalOvertime
        {
            get { return D0Overtime + D1Overtime + D2Overtime + D3Overtime + D4Overtime + D5Overtime + D6Overtime; }
        }

        [NotMapped]
        public double TotalVacation
        {
            get { return D0Vacation + D1Vacation + D2Vacation + D3Vacation + D4Vacation + D5Vacation + D6Vacation; }
        }

        [NotMapped]
        public double TotalHoliday
        {
            get { return D0Holiday + D1Holiday + D2Holiday + D3Holiday + D4Holiday + D5Holiday + D6Holiday; }
        }

        [NotMapped]
        public double TotalHours
        {
            get { return TotalRegular + TotalOvertime + TotalVacation + TotalHoliday; }
        }

    }

}




