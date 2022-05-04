using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Task1
{
    public class MotoDBIF  //Direct CRUD for Microsoft.EntityFrameworkCore.Sqlite
    {
        public static void AddMotoinDb(Moto moto, ApplicationContext db)
        {
            db.MotoSQL.Add(moto);
            db.SaveChanges();
            Console.WriteLine($"New Moto object {moto.Name} is created and put in the MotoRepository DB.");
        }

        public static void DeleteMoto(Guid id, ApplicationContext db)
        {
            Moto? moto = db.MotoSQL.Find(id);
            if (moto != null)
            {
                Console.WriteLine($"DeleteMoto: object with GUID {id}  is found in database. It's {moto.Name}. It will be removed.");
                db.MotoSQL.Remove(moto);
                db.SaveChanges();
            }
            else Console.WriteLine($"Object with GUID {id} is not found.");
        }

        public static bool UpdateMoto(Moto moto, ApplicationContext db)
        {
            Moto? mototemp = db.MotoSQL.Find(moto.Id);

            if (mototemp != null)
            {
                Console.WriteLine($"UpdateMoto: object with GUID {mototemp.Id}  is found in database. It's {mototemp.Name}. It will be replaced with your {moto.Name} Moto object.");
                db.MotoSQL.Remove(mototemp);
                db.MotoSQL.Add(moto);
                db.SaveChanges();
                return true;
            }
            Console.WriteLine($"Object with GUID {moto.Id} is not found in database.");
            Console.WriteLine("Would you like to add it to the database? Type Y/ N.");
            ContinueVerify(moto, db);
            return false;
        }

        static void ContinueVerify(Moto moto, ApplicationContext db)
        {
            string? input2 = Console.ReadLine();
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                AddMotoinDb(moto, db);
        }


        public static void GetMotosInfo(ApplicationContext db)
        {
            var collectMoto = db.MotoSQL.ToList();
            Console.WriteLine($"Motorcycle List Info from SQL DB:");
            foreach (var item in collectMoto)
            {
                Console.WriteLine(item);
            }
        }

        public static Moto GetMotoByID(Guid id, ApplicationContext db)
        {
            Moto? mototemp = db.MotoSQL.Find(id);

            if (mototemp != null)
                Console.WriteLine($"GetMotoByID: object with GUID {id}  is found. It's {mototemp.Name}.");
            else
                Console.WriteLine($"Object with GUID {id} is not found.");

            return mototemp;
        }
    }
}
