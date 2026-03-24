using System.Collections.Generic;
using EquipmentRentalApp.Data;
using EquipmentRentalApp.Models;

namespace EquipmentRentalApp.Services
{
    public class UserService
    {
        DataStore d;

        public UserService(DataStore d)
        {
            this.d = d;
        }

        public Student addStudent(string fn,string ln,string sn)
        {
            int id=d.GetNextUserId();
            Student s=new Student(id,fn,ln,sn);
            d.Users.Add(s);
            return s;
        }

        public Employee addEmployee(string fn,string ln,string dep)
        {
            int id=d.GetNextUserId();
            Employee e=new Employee(id,fn,ln,dep);
            d.Users.Add(e);
            return e;
        }

        public List<User> getAll()
        {
            return d.Users;
        }

        public User getById(int id)
        {
            for(int i=0;i<d.Users.Count;i++)
            {
                if(d.Users[i].Id==id)
                {
                    return d.Users[i];
                }
            }
            return null;
        }
    }
}