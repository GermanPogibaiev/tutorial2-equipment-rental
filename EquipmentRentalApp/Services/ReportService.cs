using EquipmentRentalApp.Data;

namespace EquipmentRentalApp.Services
{
    public class ReportService
    {
        DataStore d;

        public ReportService(DataStore d)
        {
            this.d=d;
        }

        public string rep()
        {
            int a=0,b=0,c=0;

            for(int i=0;i<d.Equipments.Count;i++)
            {
                if(d.Equipments[i].Status==Models.EquipmentStatus.Available) a++;
                else if(d.Equipments[i].Status==Models.EquipmentStatus.Rented) b++;
                else c++;
            }

            return "all:"+d.Equipments.Count+" av:"+a+" r:"+b+" un:"+c;
        }
    }
}