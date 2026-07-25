using problem_1.Entities;
using problem_1.Model;

MyContext Db = new MyContext();

Db.Database.EnsureDeleted();
Db.Database.EnsureCreated();

Musician m1 = new Musician { Name = "haifa wehbe", Street = "123 Main St", City = "lebanon", Phone = "123-456-7890" };
Musician m2 = new Musician { Name = "amr diab", Street = "456 Oak Ave", City = "egypt", Phone = "987-654-3210" };

Instrument i1 = new Instrument { Name = "Guitar", Key = "C" };
Instrument i2 = new Instrument { Name = "Piano", Key = "G" };

Song s1 = new Song { Title = "baba fen", Author = "haifa wehbe" };
Song s2 = new Song { Title = "khad alby maah", Author = "amr diab" };
Song s3 = new Song { Title = "lealy nahary", Author = "amr diab" };

Album a1 = new Album { Title = "baby haifa", CrDate = DateTime.Now, Musician = m1 };
Album a2 = new Album { Title = "lealy nahary", CrDate = DateTime.Now, Musician = m2 };

m1.Instruments.Add(i1);
m1.Instruments.Add(i2);
m2.Instruments.Add(i1);

m1.Songs.Add(s1);
m1.Songs.Add(s2);
m2.Songs.Add(s3);

s1.Album = a1;
s2.Album = a1;
s3.Album = a2;

Db.Musicians.Add(m1);
Db.Musicians.Add(m2);

Db.SaveChanges();

Console.WriteLine("database created and seeded successfully");