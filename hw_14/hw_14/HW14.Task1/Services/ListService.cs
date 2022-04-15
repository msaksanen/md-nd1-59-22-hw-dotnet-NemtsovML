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
    public class ListService<T> : IRepository<T, List<T>> where T : Transport //CRUD methods suitable for all  List<Moto> collections (also for lists loaded from JSON and/or DB).
    {
        public void AddTranspInDb(T transport, List<T> list)
        {
            if (list is List<Transport> lst && transport is Transport tr)
            {
                lst.Add(transport);
                Console.WriteLine($"New Transport object {tr.Name} is created and put in the Repository List.");
            }
            else Console.WriteLine($"A provided List {list} is not a Transport Repository List or an object {transport} is not a tranposrt and can not be put in the Repository List.");
        }

        public void DeleteTransp(Guid id, List<T> list)
        {
            if (list is List<Transport> lst)
            {
                bool IsFound = false;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (id == lst[i].Id)
                    {
                        Console.WriteLine($"Delete Transport: object with GUID {id}  is found in database. It's {lst[i].Name}. It will be removed.");
                        IsFound = lst.Remove(lst[i]);
                    }
                }
                if (IsFound == false) Console.WriteLine($"Object with GUID {id} is not found.");
            }
            else Console.WriteLine($"A provided List {list} is not a Transport Repository List.");
        }

        public bool UpdateTransp(T transport, List<T> list)
        {
            if (list is List<Transport> lst && transport is Transport transp)
            {
                int x = -1;

                Log.Debug($"Searching for object {transport}.");
                for (int i = 0; i < lst.Count; i++)
                {
                    if (transp.Id == lst[i].Id) x = i;
                }
                try
                {
                    if (x != -1)
                    {
                        Console.WriteLine($"UpdateTransport: object with GUID {transp.Id} is found in database. It's {lst[x].Name}. It will be replaced with your {transp.Name} Transport object.");
                        list[x] = transport;
                        return true;
                    }
                    else throw new TransportNotFoundException($"UpdateTransport. Object with GUID {transp.Id} is not found.");
                }
                catch (TransportNotFoundException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                    Console.WriteLine($"Exception: {e.StackTrace}");
                    Log.Error($"Exception: {e.Message}");
                    Log.Error($"Exception: {e.StackTrace}");
                }
                //for (int i = 0; i < lst.Count; i++)
                //{
                //    if (transp.Id == lst[i].Id)
                //    {
                //        Console.WriteLine($"UpdateTransport: object with GUID {transp.Id} is found in database. It's {lst[i].Name}. It will be replaced with your {transp.Name} Transport object.");
                //        list[i] = transport;
                //        return true;
                //    }
                //}
                //Console.WriteLine($"Object with GUID {transp.Id} is not found in database.");
                Console.WriteLine("Would you like to add it to the database? Type Y/ N.");
                ContinueVerify(transport, list);
            }
            else
            {
                Console.WriteLine($"A provided List {list} is not a Transport Repository List or an object {transport} is not a tranposrt and can not be put in the Repository List.");
            }
            return false;
        }

        void ContinueVerify(T transport, List<T> list)
        {
            string? input2 = Console.ReadLine();
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                AddTranspInDb(transport, list);
        }


        public void GetTranspInfo(List<T> list)
        {
            if (list is List<Transport> lst)
            {
                Console.WriteLine($"Transport List Info {lst.GetType().Name}:");
                foreach (var item in lst)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine($"A provided List {list} is not a Transport Repository List.");
        }

        public T GetByID(Guid id, List<T> list)
        {
            Transport transptemp = default;
            if (list is List<Transport> lst)
            {
                //transptemp = lst.Find(p => p.Id == id);
                //if (transptemp != default)
                //    Console.WriteLine($"GetByID: object with GUID {id}  is found. It's {transptemp.Name}.");
                //else
                //    Console.WriteLine($"Object with GUID {id} is not found.");
                try
                {
                    Log.Debug($"Searching for object with ID {id}.");
                    transptemp = lst.Find(p => p.Id == id);
                    if (transptemp != default)
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
            }
            else Console.WriteLine($"A provided List {list} is not a Transport Repository List.");
            return (T)transptemp;
        }
    }
}

