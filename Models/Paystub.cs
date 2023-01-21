namespace SPA.Models
{
    public class PayStub
    {
        private int _number;
        private DateTime _creationDate;
        private Employee _employee;
        private TimeSheet _timeSheet1;
        private TimeSheet _timeSheet2;

        public PayStub(int number, Employee employee, TimeSheet timeSheet1, TimeSheet timeSheet2)
        {
            _number = number;
            _employee = employee;
            _timeSheet1 = timeSheet1;
            _timeSheet2 = timeSheet2;
            _creationDate = DateTime.Now;
        }

        public int Number { get => _number; set => _number = value; }
        public Employee Employee { get => _employee; }
        public TimeSheet TimeSheet1 { get => _timeSheet1; }
        public TimeSheet TimeSheet2 { get => _timeSheet2; }
        public DateTime StartDate { get => _timeSheet1.WeekDate; }
        public DateTime EndDate { get => _timeSheet2.WeekDateEnd; }
        public double TotalRegular { get => _timeSheet1.TotalRegular + _timeSheet2.TotalRegular; }
        public double TotalOvertime { get => _timeSheet1.TotalOvertime + _timeSheet2.TotalOvertime; }
        public double TotalVacation { get => _timeSheet1.TotalVacation + _timeSheet2.TotalVacation; }
        public double TotalHoliday { get => _timeSheet1.TotalHoliday + _timeSheet2.TotalHoliday; }
        public double TotalHours { get => TotalRegular + TotalOvertime + TotalVacation + TotalHoliday; }
        
        public DateTime CreationDate { get => _creationDate; }
        public double Gross => Employee.Rate * (_timeSheet1.TotalHours + _timeSheet1.TotalHours);
        public double FedTax => Gross * Employee.FedTax * 0.01;
        public double ProvTax => Gross * Employee.ProvTax * 0.01;
        public double RRQ => Gross * Employee.RRQ * 0.01;
        public double RQAP => Gross * Employee.RQAP * 0.01;
        public double Vacation => Gross * Employee.Vacation * 0.01;
        public double Deductions => FedTax + ProvTax + RRQ + RQAP + Vacation;
        public double Net => Gross - Deductions;

    }
}