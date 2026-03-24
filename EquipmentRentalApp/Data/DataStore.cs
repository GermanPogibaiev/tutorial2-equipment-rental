using System.Collections.Generic;
using EquipmentRentalApp.Models;

namespace EquipmentRentalApp.Data
{
    public class DataStore
    {
        public List<User> Users { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<Rental> Rentals { get; set; }

        private int nextUserId = 1;
        private int nextEquipmentId = 1;
        private int nextRentalId = 1;

        public DataStore()
        {
            Users = new List<User>();
            Equipments = new List<Equipment>();
            Rentals = new List<Rental>();
        }

        public int GetNextUserId()
        {
            int id = nextUserId;
            nextUserId++;
            return id;
        }

        public int GetNextEquipmentId()
        {
            int id = nextEquipmentId;
            nextEquipmentId++;
            return id;
        }

        public int GetNextRentalId()
        {
            int id = nextRentalId;
            nextRentalId++;
            return id;
        }
    }
}