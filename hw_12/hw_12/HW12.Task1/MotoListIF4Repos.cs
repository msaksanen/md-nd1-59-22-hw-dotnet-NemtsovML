using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Task1
{
    public class MotoListIF4Repos : IMotoCRUD //CRUD methods suitable for all  List<Moto> collections (also for lists loaded from JSON and/or DB).
    {
        public void AddMotoinDb(Moto moto, List<Moto> list)
        {
            list.Add(moto);
            Console.WriteLine($"New Moto object {moto.Name} is created and put in the MotoRepository List.");
        }

        public void DeleteMoto(Guid id, List<Moto> list)
        {
            bool IsFound = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list[i].Id)
                {
                    Console.WriteLine($"DeleteMoto: object with GUID {id}  is found in database. It's {list[i].Name}. It will be removed.");
                    IsFound = list.Remove(list[i]);
                }
            }
            if (IsFound == false) Console.WriteLine($"Object with GUID {id} is not found.");
        }

        public bool UpdateMoto(Moto moto, List<Moto> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (moto.Id == list[i].Id)
                {
                    Console.WriteLine($"UpdateMoto: object with GUID {moto.Id}  is found in database. It's {list[i].Name}. It will be replaced with your {moto.Name} Moto object.");
                    list[i] = moto;
                    return true;
                }
            }
            Console.WriteLine($"Object with GUID {moto.Id} is not found in database.");
            Console.WriteLine("Woulda you like to add it to the database? Type Y/ N.");
            ContinueVerify(moto, list);
            return false;
        }

        void ContinueVerify(Moto moto, List<Moto> list)
        {
            string? input2 = Console.ReadLine();
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                AddMotoinDb(moto, list);
        }


        public void GetMotosInfo(List<Moto> list)
        {
            var collectMoto = list;
            Console.WriteLine($"Motorcycle List Info {list.GetType().Name}:");
            foreach (var item in collectMoto)
            {
                Console.WriteLine(item);
            }
        }

        public Moto GetMotoByID(Guid id, List<Moto> list)
        {
            var collectMoto = list;
            Moto mototemp = default;
            mototemp = collectMoto.Find(p => p.Id == id);
            if (mototemp != default)
                Console.WriteLine($"GetMotoByID: object with GUID {id}  is found. It's {mototemp.Name}.");
            else
                Console.WriteLine($"Object with GUID {id} is not found.");

            return mototemp;
        }
    }
}
