using problem_2.Entities;
using problem_2.Model;

MyContext Db = new MyContext();

Db.Database.EnsureDeleted();
Db.Database.EnsureCreated();

SalesOffice so1 = new SalesOffice { Num = 1, Location = "portsaid" };
SalesOffice so2 = new SalesOffice { Num = 2, Location = "alex" };

Employee e1 = new Employee { Name = "shehap" };
Employee e2 = new Employee { Name = "Sara" };
Employee e3 = new Employee { Name = "heba" };

Property p1 = new Property { Address = "123 Main St", City = "Cairo", State = "Cairo", Zip = "12345" };
Property p2 = new Property { Address = "456 Oak Ave", City = "Alex", State = "Alex", Zip = "67890" };

Owner o1 = new Owner { Name = "Mohamed" };
Owner o2 = new Owner { Name = "Nada" };

Db.SalesOffices.Add(so1);
Db.SalesOffices.Add(so2);
Db.SaveChanges();

e1.SalesOffice = so1;
e2.SalesOffice = so1;
e3.SalesOffice = so2;

p1.SalesOffice = so1;
p2.SalesOffice = so2;

Db.Employees.Add(e1);
Db.Employees.Add(e2);
Db.Employees.Add(e3);

Db.SaveChanges();

so1.Manager = e1;

Db.Properties.Add(p1);
Db.Properties.Add(p2);
Db.Owners.Add(o1);
Db.Owners.Add(o2);

Db.SaveChanges();

PropertyOwner po1 = new PropertyOwner { Property = p1, Owner = o1, PercentOwned = 60 };
PropertyOwner po2 = new PropertyOwner { Property = p1, Owner = o2, PercentOwned = 40 };
PropertyOwner po3 = new PropertyOwner { Property = p2, Owner = o1, PercentOwned = 100 };

Db.PropertyOwners.Add(po1);
Db.PropertyOwners.Add(po2);
Db.PropertyOwners.Add(po3);

Db.SaveChanges();

Console.WriteLine("database created and seeded successfully");