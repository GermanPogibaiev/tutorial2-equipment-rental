using System.Collections.Generic;
using EquipmentRentalApp.Data;
using EquipmentRentalApp.Models;

namespace EquipmentRentalApp.Services
{
    public class EquipmentService
    {
        DataStore d;

        public EquipmentService(DataStore d)
        {
            this.d=d;
        }

        public Laptop addLaptop(string n,int r,string c)
        {
            int id=d.GetNextEquipmentId();
            Laptop l=new Laptop(id,n,r,c);
            d.Equipments.Add(l);
            return l;
        }

        public Projector addProjector(string n,string res,int b)
        {
            int id=d.GetNextEquipmentId();
            Projector p=new Projector(id,n,res,b);
            d.Equipments.Add(p);
            return p;
        }

        public Camera addCamera(string n,int mp,bool v)
        {
            int id=d.GetNextEquipmentId();
            Camera c=new Camera(id,n,mp,v);
            d.Equipments.Add(c);
            return c;
        }

        public List<Equipment> getAll()
        {
            return d.Equipments;
        }

        public List<Equipment> getAvail()
        {
            List<Equipment> l=new List<Equipment>();
            for(int i=0;i<d.Equipments.Count;i++)
            {
                if(d.Equipments[i].Status==EquipmentStatus.Available)
                {
                    l.Add(d.Equipments[i]);
                }
            }
            return l;
        }

        public Equipment getById(int id)
        {
            for(int i=0;i<d.Equipments.Count;i++)
            {
                if(d.Equipments[i].Id==id)
                {
                    return d.Equipments[i];
                }
            }
            return null;
        }

        public void setUn(int id)
        {
            Equipment e=getById(id);
            if(e!=null)
            {
                e.Status=EquipmentStatus.Unavailable;
            }
        }
    }
}