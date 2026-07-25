using Assignment.Entities;
using Assignment.Model;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyContext Db = new MyContext();
            Db.Database.EnsureDeleted();
            Db.Database.EnsureCreated();



            Hospital H1 = new Hospital { Name = "porto Hospital", Location = "portsaid" };
            Hospital H2 = new Hospital { Name = "Giza Hospital", Location = "Giza" };
            Hospital H3 = new Hospital { Name = "alex Hospital", Location = "Alexandria" };

            Doctor D1 = new Doctor { FirstName = "shehap", LastName = "sherif", Hospital = H1 };
            Doctor D2 = new Doctor { FirstName = "ahmed", LastName = "sherif", Hospital = H1 };
            Doctor D3 = new Doctor { FirstName = "islam", LastName = "Khaled", Hospital = H2 };

            Patient P1 = new Patient { FirstName = "mariam", LastName = "Youssef" };
            Patient P2 = new Patient { FirstName = "Nada", LastName = "Ibrahim" };
            Patient P3 = new Patient { FirstName = "yousif", LastName = "Mostafa" };

            Appointment A1 = new Appointment { Doctor = D1, Patient = P1 };
            Appointment A2 = new Appointment { Doctor = D1, Patient = P2 };
            Appointment A3 = new Appointment { Doctor = D2, Patient = P3 };
            Appointment A4 = new Appointment { Doctor = D3, Patient = P1 };

            Db.Hospitals.Add(H1);
            Db.Hospitals.Add(H2);
            Db.Hospitals.Add(H3);

            Db.Doctors.Add(D1);
            Db.Doctors.Add(D2);
            Db.Doctors.Add(D3);

            Db.Patients.Add(P1);
            Db.Patients.Add(P2);
            Db.Patients.Add(P3);

            Db.Appointments.Add(A1);
            Db.Appointments.Add(A2);
            Db.Appointments.Add(A3);
            Db.Appointments.Add(A4);

            try
            {
                Db.SaveChanges();
                Console.WriteLine("Saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("INNER: " + ex.InnerException.Message);
            }
            Console.ReadLine(); // keeps window open so you can read it
        }
    }
}