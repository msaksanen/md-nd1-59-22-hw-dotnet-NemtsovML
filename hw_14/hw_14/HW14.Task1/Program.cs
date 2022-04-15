using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HW14.Task1.Enitities;
using HW14.Task1.Interfaces;
using HW14.Task1.Repositories;
using HW14.Task1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace HW14.Task1
{
    class Program
    {
        static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.Debug()
                         .Enrich.FromLogContext()
                         .WriteTo.File(@"D:\log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
                         .WriteTo.Console()
                         .CreateLogger();
            Log.Information("Serilog logging started");

            Moto honda = new() { Manufacturer = "Honda", Model = "CX7", Name = "HardRider", ReleaseDate = new DateTime(2015, 7, 20), Odometer = 5330 };
            Moto minsk = new() { Manufacturer = "Minsk", Model = "MK22", Name = "Minsky", ReleaseDate = new DateTime(1995, 8, 24), Odometer = 15330 };
            Moto izh = new() { Manufacturer = "IZH", Model = "IV35", Name = "Izhevsk", ReleaseDate = new DateTime(1989, 3, 30), Odometer = 123300 };
            Moto java = new() { Manufacturer = "Java", Model = "JV34", Name = "Java Next", ReleaseDate = new DateTime(1999, 3, 30), Odometer = 12330 };
            Moto harley = new() { Manufacturer = "Harley-Davidson", Model = "HD27", Name = "Harley Roadster", ReleaseDate = new DateTime(2005, 3, 22), Odometer = 125330 };

            //ListService<Transport> listService = new ListService <Transport>();
            IRepository<Transport, List<Transport>> listService_i = new ListService<Transport>();
            ListRepos<Transport> listRepos = new ListRepos<Transport>();

            listService_i.AddTranspInDb(honda, listRepos.Repos);
            listService_i.AddTranspInDb(minsk, listRepos.Repos);
            listService_i.AddTranspInDb(java, listRepos.Repos);
            listService_i.AddTranspInDb(harley, listRepos.Repos);
            listService_i.AddTranspInDb(izh, listRepos.Repos);
            listService_i.GetTranspInfo(listRepos.Repos);
            listService_i.DeleteTransp(izh.Id, listRepos.Repos);

            Moto moto2 = new() { Manufacturer = "Minsk", Model = "MK45", Name = "Minsky New", ReleaseDate = new DateTime(1999, 8, 24), Odometer = 25330 };
            moto2.Id = minsk.Id;
            listService_i.UpdateTransp(moto2, listRepos.Repos); //Updates info by ID.
            Moto moto3 = new() { Manufacturer = "Minsk", Model = "MK32", Name = "Minsk Old", ReleaseDate = new DateTime(1982, 8, 24), Odometer = 525330 };
            listService_i.UpdateTransp(moto3, listRepos.Repos);  //Exception

            Guid id2 = java.Id;
            Transport new_transport = listService_i.GetByID(id2, listRepos.Repos);  //Gets moto by ID.
            Transport new_transport2 = listService_i.GetByID(Guid.NewGuid(), listRepos.Repos); //Exception

            listService_i.GetTranspInfo(listRepos.Repos);

            Car honda_car = new() { Manufacturer = "Honda", Model = "XW2", Name = "Civic", ReleaseDate = new DateTime(2010, 7, 20), Odometer = 125330 };
            Car bmw = new() { Manufacturer = "BMW", Model = "X6", Name = "BMW", ReleaseDate = new DateTime(2005, 7, 22), Odometer = 325330 };
            Car audi = new() { Manufacturer = "Audi", Model = "Q6", Name = "Audi", ReleaseDate = new DateTime(2019, 8, 20), Odometer = 225330 };

            listService_i.AddTranspInDb(honda_car, listRepos.Repos);
            listService_i.AddTranspInDb(bmw, listRepos.Repos);
            listService_i.AddTranspInDb(audi, listRepos.Repos);

            listService_i.GetTranspInfo(listRepos.Repos);

            //Indexing attempt. View also ListRepository. It works but it's useless.
            //ListRepos<Transport> testrepos = new ListRepos<Transport>();
            //testrepos[1] = new List<Transport>(25);
            //listService_i.AddTranspInDb(audi, testrepos[1]);
            //listService_i.GetTranspInfo(testrepos[1]);
            //testrepos[2] = new List<Transport>(25);
            //listService_i.AddTranspInDb(bmw, testrepos[2]);
            //listService_i.GetTranspInfo(testrepos[2]);

            ListRepos<Transport> fileRepos = new ListRepos<Transport>();      //New repository for JSON.
            //fileRepos.Repos = listRepos.Repos;
            fileRepos.Path = @"D:\user2.json";

            IRepository<Transport, ListRepos<Transport>> jsonService_i = new JsonService<Transport>();

            JsonService<Transport> jsonService = jsonService_i as JsonService<Transport>;

            jsonService.SaveListToFile(listRepos.Repos, fileRepos.Path);
            jsonService_i.GetTranspInfo(fileRepos);

            jsonService.ClearJSON(fileRepos.Path);
            jsonService_i.GetTranspInfo(fileRepos);


            jsonService.SaveListToFile(listRepos.Repos, fileRepos.Path);
            jsonService.LoadFileToList(fileRepos);
            jsonService_i.GetTranspInfo(fileRepos);

            Moto kawaski = new() { Manufacturer = "Kawasaki", Model = "K217", Name = "Banzai", ReleaseDate = new DateTime(2000, 11, 22), Odometer = 129330 };
            Moto yamaha = new() { Manufacturer = "Yamaha", Model = "Y17", Name = "Yamato", ReleaseDate = new DateTime(2010, 11, 12), Odometer = 125330 };
            jsonService_i.AddTranspInDb(kawaski, fileRepos);
            jsonService_i.AddTranspInDb(yamaha, fileRepos);
            jsonService_i.GetTranspInfo(fileRepos);
            jsonService_i.DeleteTransp(kawaski.Id, fileRepos);
            Transport new_transport3 = jsonService_i.GetByID(Guid.NewGuid(), fileRepos); //Exception
            Moto moto4 = new() { Manufacturer = "KTM", Model = "KT32", Name = "KTM-X", ReleaseDate = new DateTime(1999, 3, 24), Odometer = 225330 };
            jsonService_i.UpdateTransp(moto4, fileRepos);  //Exception
            jsonService_i.GetTranspInfo(fileRepos);

            Car audi2 = new() { Manufacturer = "Audi", Model = "Q8", Name = "Audi", ReleaseDate = new DateTime(2021, 8, 20), Odometer = 125330 };
            audi2.Id = audi.Id;
            jsonService_i.UpdateTransp(audi2, fileRepos);
            jsonService_i.GetTranspInfo(fileRepos);

            ListRepos<Transport> fileSQLRepos = new ListRepos<Transport>(); //New repository for SQL.
            fileSQLRepos.Repos = listRepos.Repos;
            fileSQLRepos.Path = @"Data Source = D:\user2.db";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext<Transport>>();
            var options = optionsBuilder.UseSqlite(fileSQLRepos.Path).Options;
            ApplicationContext<Transport> db = new ApplicationContext<Transport>(options); //DB context.

            Moto yamaha2 = new() { Manufacturer = "Yamaha2", Model = "Y27", Name = "Nippon", ReleaseDate = new DateTime(2012, 11, 12), Odometer = 225330 };
            Moto kawaski2 = new() { Manufacturer = "Kawasaki2", Model = "K3E17", Name = "Senko", ReleaseDate = new DateTime(2018, 11, 22), Odometer = 109330 };

            db.TranspSQL.Add(yamaha2);
            db.TranspSQL.Add(kawaski2);
            db.SaveChanges();
            Console.WriteLine("Objects are saved in DataBase.");

            fileSQLRepos.Repos = db.TranspSQL.ToList();
            Console.WriteLine("List of objects in DB:");
            foreach (Transport m in fileSQLRepos.Repos)
            {
                Console.WriteLine(m);
            }

            //db.TranspSQL.AddRange(fileRepos.Repos);
            db.TranspSQL.AddRange(listRepos.Repos);
            db.SaveChanges();
            Console.WriteLine("Objects of previous base are appended to in SQL DataBase.");
            fileSQLRepos.Repos = db.TranspSQL.ToList();
            Console.WriteLine("List of objects in DB:");
            foreach (Transport m in fileSQLRepos.Repos)
            {
                Console.WriteLine(m);
            }

            Moto suzuki = new() { Manufacturer = "Suzuki", Model = "SZ17", Name = "Isuzu", ReleaseDate = new DateTime(2012, 11, 22), Odometer = 103330 };
            IRepository<Transport, ApplicationContext<Transport>> dbRepos = new DbaseService<Transport>();

            dbRepos.AddTranspInDb(suzuki, db); //CRUD SQL
            dbRepos.DeleteTransp(minsk.Id, db);
            dbRepos.GetTranspInfo(db);
            Transport new_transport4 = dbRepos.GetByID(Guid.NewGuid(), db); //Exception

            Moto yamaha3 = new() { Manufacturer = "Yamaha3", Model = "Y27", Name = "Toto", ReleaseDate = new DateTime(2010, 11, 12), Odometer = 225230 };
            yamaha3.Id = yamaha.Id;
            dbRepos.UpdateTransp(yamaha3, db);  //Exception. Yamaha is not included in the current db. 
            Transport new_moto2 = dbRepos.GetByID(yamaha3.Id, db);

            dbRepos.GetTranspInfo(db);

            Log.Information("Serilog logging finished");
            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}
