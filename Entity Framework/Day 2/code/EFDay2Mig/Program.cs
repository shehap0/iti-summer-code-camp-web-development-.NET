using EFDay2Mig.Entities;
using EFDay2Mig.Models;

namespace EFDay2Mig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // most commonly used strategy [Migrate]
            // Make EF do changes in DB Without drop DB or Truncate Date

            // Migration will be done in Versions
        
            MyContext Db = new MyContext();


            Instructor ins = new Instructor { Name = "Mohmmed", Age = 35, Salary = 5000, Address = "cairo", Email= "Mohmmed@gmail.com"};

            Db.Instructors.Add(ins);


            Db.SaveChanges();
        }
    }
}
