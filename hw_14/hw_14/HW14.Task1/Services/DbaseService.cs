using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW14.Task1.Enitities;
using HW14.Task1.Interfaces;
using Serilog;


namespace HW14.Task1.Services
{
    public class DbaseService<T> : IRepository<T, ApplicationContext<T>> where T : Transport   //Direct CRUD for Microsoft.EntityFrameworkCore.Sqlite
    {
        public void AddTranspInDb(T transport, ApplicationContext<T> db)
        {
            if (transport is Transport && db is ApplicationContext<Transport>)
            {
                db.TranspSQL.Add(transport);
                db.SaveChanges();
                Console.WriteLine($"New Transport object {transport.Name} is created and put in the Transport Repository DB.");
            }
            else Console.WriteLine($"A provided Databse {db} is not a Transport Repository DB or an object {transport} is not a tranposrt and can not be put in the Repository DB.");
        }

        public void DeleteTransp(Guid id, ApplicationContext<T> db)
        {
            if (db is ApplicationContext<Transport>)
            {
                T? transp = db.TranspSQL.Find(id);
                if (transp != null)
                {
                    Console.WriteLine($"Delete Transport: object with GUID {id}  is found in database. It's {transp.Name}. It will be removed.");
                    db.TranspSQL.Remove(transp);
                    db.SaveChanges();
                }
                else Console.WriteLine($"Object with GUID {id} is not found.");
            }
            else Console.WriteLine($"A provided Databse {db} is not a Transport Repository DB.");
        }

        public bool UpdateTransp(T transport, ApplicationContext<T> db)
        {
            if (transport is Transport && db is ApplicationContext<Transport>)
            {
                Log.Debug($"Searching for object {transport}.");
                T? transptemp = db.TranspSQL.Find(transport.Id);
                try
                {
                    if (transptemp != null)
                    {
                        Console.WriteLine($"Update Transport: object with GUID {transptemp.Id}  is found in database. It's {transptemp.Name}. It will be replaced with your {transport.Name} object.");
                        db.TranspSQL.Remove(transptemp);
                        db.TranspSQL.Add(transport);
                        db.SaveChanges();
                        return true;
                    }
                    else
                        throw new TransportNotFoundException($"Update Transport:Object with GUID {transport.Id} is not found in database.");
                }
                catch (TransportNotFoundException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                    Console.WriteLine($"Exception: {e.StackTrace}");
                    Log.Error($"Exception: {e.Message}");
                    Log.Error($"Exception: {e.StackTrace}");
                }

                //  if (transptemp != null)
                //  {
                //  Console.WriteLine($"Update Transport: object with GUID {transptemp.Id}  is found in database. It's {transptemp.Name}. It will be replaced with your {transport.Name} object.");
                //  db.TranspSQL.Remove(transptemp);
                //  db.TranspSQL.Add(transport);
                //  db.SaveChanges();
                //  return true;
                //  }
                //Console.WriteLine($"Object with GUID {transport.Id} is not found in database.");
                Console.WriteLine("Would you like to add it to the database? Type Y/ N.");
                ContinueVerify(transport, db);
            }
            else Console.WriteLine($"A provided Databse {db} is not a Transport Repository DB or an object {transport} is not a tranposrt and can not be put in the Repository DB.");
            return false;
        }

        void ContinueVerify(T transport, ApplicationContext<T> db)
        {
            string? input2 = Console.ReadLine();
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                AddTranspInDb(transport, db);
        }

        public void GetTranspInfo(ApplicationContext<T> db)
        {
            if (db is ApplicationContext<Transport>)
            {
                var collectTransp = db.TranspSQL.ToList();
                Console.WriteLine($"Transport List Info from SQL DB:");
                foreach (var item in collectTransp)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine($"A provided Databse {db} is not a Transport Repository DB.");
        }

        public T GetByID(Guid id, ApplicationContext<T> db)
        {
            T? transptemp = default;
            Log.Debug($"Searching for object  with ID{id}.");
            if (db is ApplicationContext<Transport>)
            {
                try
                {
                    transptemp = db.TranspSQL.Find(id);
                    if (transptemp != null)
                        Console.WriteLine($"GetByID: object with GUID {id}  is found. It's {transptemp.Name}.");
                    else
                        throw new TransportNotFoundException($"GetByID. Object with GUID {id} is not found.");
                }
                catch (TransportNotFoundException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                    Console.WriteLine($"Exception: {e.StackTrace}");
                    Log.Error($"Exception: {e.Message}");
                    Log.Error($"Exception: {e.StackTrace}");
                }

                //    transptemp = db.TranspSQL.Find(id);
                //if (transptemp != null)
                //    Console.WriteLine($"GetByID: object with GUID {id}  is found. It's {transptemp.Name}.");
                //else
                //    Console.WriteLine($"Object with GUID {id} is not found.");
            }
            else Console.WriteLine($"A provided Databse {db} is not a Transport Repository DB.");

            return transptemp;
        }
    }
}