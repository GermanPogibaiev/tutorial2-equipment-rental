using System;

namespace EquipmentRentalApp.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg)
        {
        }
    }
}