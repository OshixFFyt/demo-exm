using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_exm
{
    public class Shift
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<User> Employees { get; set; }

        public Shift(DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Employees = new List<User>();
        }
        public void AddEmployee(User employee)
        {
            Employees.Add(employee);
        }
    }

}
