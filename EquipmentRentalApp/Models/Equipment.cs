namespace EquipmentRentalApp.Models
{
    public abstract class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentStatus Status { get; set; }

        public Equipment(int id, string name)
        {
            Id = id;
            Name = name;
            Status = EquipmentStatus.Available;
        }

        public override string ToString()
        {
            return "Id: " + Id + ", Name: " + Name + ", Status: " + Status;
        }
    }
}