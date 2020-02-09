using Domain.Enum;

namespace Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
       
        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public EmployeeFunctie Functie { get; set; }


    }
}