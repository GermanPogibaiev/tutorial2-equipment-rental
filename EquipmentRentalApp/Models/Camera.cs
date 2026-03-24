namespace EquipmentRentalApp.Models
{
    public class Camera : Equipment
    {
        public int MegaPixels { get; set; }
        public bool HasVideo { get; set; }

        public Camera(int id, string name, int megaPixels, bool hasVideo) : base(id, name)
        {
            MegaPixels = megaPixels;
            HasVideo = hasVideo;
        }

        public override string ToString()
        {
            return base.ToString() + ", MP: " + MegaPixels + ", Video: " + HasVideo;
        }
    }
}