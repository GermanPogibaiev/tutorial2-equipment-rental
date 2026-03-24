using System;

namespace EquipmentRentalApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Equipment Equipment { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal Penalty { get; set; }

        public Rental(int id, User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
        {
            Id = id;
            User = user;
            Equipment = equipment;
            RentalDate = rentalDate;
            DueDate = dueDate;
            ActualReturnDate = null;
            Penalty = 0;
        }

        public bool IsReturned()
        {
            return ActualReturnDate != null;
        }

        public bool IsOverdue()
        {
            if (ActualReturnDate == null)
            {
                return DateTime.Now > DueDate;
            }

            return ActualReturnDate > DueDate;
        }

        public override string ToString()
        {
            string ret = ActualReturnDate == null ? "Not returned" : ActualReturnDate.ToString();
            return "Rental Id: " + Id + ", User: " + User.FirstName + " " + User.LastName +
                   ", Equipment: " + Equipment.Name + ", From: " + RentalDate +
                   ", Due: " + DueDate + ", Return: " + ret + ", Penalty: " + Penalty;
        }
    }
}