using System;

namespace EquipmentRentalApp.Exceptions
{
    public class RentalException : Exception
    {
        public RentalException(string msg) : base(msg)
        {
        }
    }
}