using System;
using System.Collections.Generic;
using EquipmentRentalApp.Data;
using EquipmentRentalApp.Models;

namespace EquipmentRentalApp.Services
{
    public class RentalService
    {
        DataStore d;

        public RentalService(DataStore d)
        {
            this.d=d;
        }

        public Rental rent(User u,Equipment e,int days)
        {
            if(e.Status!=EquipmentStatus.Available)
            {
                return null;
            }

            int cnt=0;

            for(int i=0;i<d.Rentals.Count;i++)
            {
                if(d.Rentals[i].User.Id==u.Id && d.Rentals[i].ActualReturnDate==null)
                {
                    cnt++;
                }
            }

            if(u.UserType==UserType.Student && cnt>=2) return null;
            if(u.UserType==UserType.Employee && cnt>=5) return null;

            int id=d.GetNextRentalId();

            Rental r=new Rental(id,u,e,DateTime.Now,DateTime.Now.AddDays(days));

            d.Rentals.Add(r);
            e.Status=EquipmentStatus.Rented;

            return r;
        }

        public decimal ret(int id)
        {
            Rental r=null;

            for(int i=0;i<d.Rentals.Count;i++)
            {
                if(d.Rentals[i].Id==id)
                {
                    r=d.Rentals[i];
                }
            }

            if(r==null) return 0;

            r.ActualReturnDate=DateTime.Now;

            if(r.ActualReturnDate>r.DueDate)
            {
                int days=(r.ActualReturnDate.Value.Date-r.DueDate.Date).Days;
                r.Penalty=days*10;
            }

            r.Equipment.Status=EquipmentStatus.Available;

            return r.Penalty;
        }

        public List<Rental> act(int uid)
        {
            List<Rental> l=new List<Rental>();

            for(int i=0;i<d.Rentals.Count;i++)
            {
                if(d.Rentals[i].User.Id==uid && d.Rentals[i].ActualReturnDate==null)
                {
                    l.Add(d.Rentals[i]);
                }
            }

            return l;
        }

        public List<Rental> over()
        {
            List<Rental> l=new List<Rental>();

            for(int i=0;i<d.Rentals.Count;i++)
            {
                if(d.Rentals[i].ActualReturnDate==null && DateTime.Now>d.Rentals[i].DueDate)
                {
                    l.Add(d.Rentals[i]);
                }
            }

            return l;
        }
    }
}