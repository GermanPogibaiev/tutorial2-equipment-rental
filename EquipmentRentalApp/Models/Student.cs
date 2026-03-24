namespace EquipmentRentalApp.Models
{
    public class Student : User
    {
        public string StudentNumber { get; set; }

        public Student(int id, string firstName, string lastName, string studentNumber)
            : base(id, firstName, lastName, UserType.Student)
        {
            StudentNumber = studentNumber;
        }

        public override string ToString()
        {
            return base.ToString() + ", Student No: " + StudentNumber;
        }
    }
}