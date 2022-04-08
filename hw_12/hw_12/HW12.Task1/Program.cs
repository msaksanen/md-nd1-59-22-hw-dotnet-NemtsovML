using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HW12.Task1
{
    class Program
    {
        static void Main()
        {
            Moto honda = new() { Manufacturer = "Honda", Model = "CX7", Name = "HardRider", ReleaseDate = new DateTime(2015, 7, 20), Odometer = 5330 };
            Moto minsk = new() { Manufacturer = "Minsk", Model = "MK22", Name = "Minsky", ReleaseDate = new DateTime(1995, 8, 24), Odometer = 15330 };
            Moto izh = new() { Manufacturer = "IZH", Model = "IV35", Name = "Izhevsk", ReleaseDate = new DateTime(1989, 3, 30), Odometer = 123300 };
            Moto java = new() { Manufacturer = "Java", Model = "JV34", Name = "Java Next", ReleaseDate = new DateTime(1999, 3, 30), Odometer = 12330 };
            Moto harley = new() { Manufacturer = "Harley-Davidson", Model = "HD27", Name = "Harley Roadster", ReleaseDate = new DateTime(2005, 3, 22), Odometer = 125330 };

            MotoListIF4Repos motoListIF4Repos = new MotoListIF4Repos();
            MotoFileRepos motorepos = new MotoFileRepos();
            motoListIF4Repos.AddMotoinDb(honda, motorepos.Repos);
            motoListIF4Repos.AddMotoinDb(minsk, motorepos.Repos);
            motoListIF4Repos.AddMotoinDb(java, motorepos.Repos);
            motoListIF4Repos.AddMotoinDb(harley, motorepos.Repos);
            motoListIF4Repos.AddMotoinDb(izh, motorepos.Repos);

            motoListIF4Repos.GetMotosInfo(motorepos.Repos);

            motoListIF4Repos.DeleteMoto(izh.Id, motorepos.Repos);

            Moto moto2 = new() { Manufacturer = "Minsk", Model = "MK45", Name = "Minsky New", ReleaseDate = new DateTime(1999, 8, 24), Odometer = 25330 };
            moto2.Id = minsk.Id;
            motoListIF4Repos.UpdateMoto(moto2, motorepos.Repos); //Updates info by ID.

            Guid id2 = java.Id;
            Moto new_moto = motoListIF4Repos.GetMotoByID(id2, motorepos.Repos);  //Gets moto by ID.

            motoListIF4Repos.GetMotosInfo(motorepos.Repos);

            MotoFileRepos fileRepos = new(); //New repository for JSON.
            fileRepos.Repos = motorepos.Repos;
            fileRepos.Path = @"D:\user2.json";

            MotoJSONRepos.SaveDBToFile(fileRepos.Repos, fileRepos.Path);
            fileRepos.Repos.Clear();
            Console.WriteLine("JSON-related <Moto> List cleared.");
            //motoListIF4Repos.GetMotosInfo(fileRepos.Repos);

            fileRepos.Repos = MotoJSONRepos.LoadFileToDb(fileRepos.Repos, fileRepos.Path);
            motoListIF4Repos.GetMotosInfo(fileRepos.Repos);

            Moto kawaski = new() { Manufacturer = "Kawasaki", Model = "K217", Name = "Banzai", ReleaseDate = new DateTime(2000, 11, 22), Odometer = 129330 };
            motoListIF4Repos.AddMotoinDb(kawaski, fileRepos.Repos);

            MotoJSONRepos.SaveDBToFile(fileRepos.Repos, fileRepos.Path);
            fileRepos.Repos = MotoJSONRepos.LoadFileToDb(fileRepos.Repos, fileRepos.Path);
            motoListIF4Repos.GetMotosInfo(fileRepos.Repos);

            Moto yamaha = new() { Manufacturer = "Yamaha", Model = "Y17", Name = "Yamato", ReleaseDate = new DateTime(2010, 11, 12), Odometer = 125330 };
            motoListIF4Repos.AddMotoinDb(yamaha, fileRepos.Repos);

            MotoJSONRepos.SaveDBToFile(fileRepos.Repos, fileRepos.Path);
            fileRepos.Repos = MotoJSONRepos.LoadFileToDb(fileRepos.Repos, fileRepos.Path);

            motoListIF4Repos.GetMotosInfo(fileRepos.Repos);

            MotoFileRepos fileSQLRepos = new();   //New repository for SQL.
            fileSQLRepos.Repos = motorepos.Repos;
            fileSQLRepos.Path = @"Data Source = D:\user2.db";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlite(fileSQLRepos.Path).Options;
            ApplicationContext db = new ApplicationContext(options); //DB context.

            Moto yamaha2 = new() { Manufacturer = "Yamaha2", Model = "Y27", Name = "Nippon", ReleaseDate = new DateTime(2012, 11, 12), Odometer = 225330 };
            Moto kawaski2 = new() { Manufacturer = "Kawasaki2", Model = "K3E17", Name = "Senko", ReleaseDate = new DateTime(2018, 11, 22), Odometer = 109330 };

            db.MotoSQL.Add(yamaha2);
            db.MotoSQL.Add(kawaski2);
            db.SaveChanges();
            Console.WriteLine("Objects are saved in DataBase.");

            fileSQLRepos.Repos = db.MotoSQL.ToList();
            Console.WriteLine("List of objects in DB:");
            foreach (Moto m in fileSQLRepos.Repos)
            {
                Console.WriteLine(m);
            }

            db.MotoSQL.AddRange(fileRepos.Repos);
            db.SaveChanges();
            Console.WriteLine("Objects of previous base are appended to in SQL DataBase.");
            fileSQLRepos.Repos = db.MotoSQL.ToList();
            Console.WriteLine("List of objects in DB:");
            foreach (Moto m in fileSQLRepos.Repos)
            {
                Console.WriteLine(m);
            }
           
            Moto suzuki = new() { Manufacturer = "Suzuki", Model = "SZ17", Name = "Isuzu", ReleaseDate = new DateTime(2012, 11, 22), Odometer = 103330 };
            MotoDBIF.AddMotoinDb(suzuki, db); //CRUD SQL
            MotoDBIF.DeleteMoto(minsk.Id, db);
            MotoDBIF.GetMotosInfo(db);

            Moto yamaha3 = new() { Manufacturer = "Yamaha3", Model = "Y27", Name = "Toto", ReleaseDate = new DateTime(2010, 11, 12), Odometer = 225230 };
            yamaha3.Id = yamaha.Id;
            MotoDBIF.UpdateMoto(yamaha3, db);
            Moto new_moto2 = MotoDBIF.GetMotoByID(yamaha3.Id, db);

            MotoDBIF.GetMotosInfo(db);

            Console.ReadKey();
        }
    }
}
