using HW14.Task1.Enitities;
using HW14.Task1.Interfaces;
using HW14.Task1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Serilog;


namespace HW14.Task1.Services
{
    public class JsonService<T> : IRepository<T, ListRepos<T>> where T : Transport
        //Load JSON file to Collection List. Save Collection to JSON file. Direct CRUD to JSON file.
    {
        public void LoadFileToList(ListRepos<T> repos)
        {
            try
            {
                using StreamReader file = File.OpenText(repos.Path);
                JsonSerializer serializer = new JsonSerializer();
                Log.Debug($"Loading JSON file to Repository Collection from: {repos.Path}.");
                Console.WriteLine($"Transport database loaded from Repository JSON file at: " + repos.Path);
                repos.Repos = (List<T>)serializer.Deserialize(file, typeof(List<T>));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                Console.WriteLine($"Exception: {e.StackTrace}");
                Log.Error($"Exception: {e.Message}");
                Log.Error($"Exception: {e.StackTrace}");
            }
        }
        public List<T> LoadFileToList(List<T> list, string path)
        {
            try
            {
                using StreamReader file = File.OpenText(path);
                JsonSerializer serializer = new JsonSerializer();
                Log.Debug($"Loading JSON file to Repository Collection from: {path}.");
                Console.WriteLine($"Transport database loaded from Repository JSON file at: " + path);
                return (List<T>)serializer.Deserialize(file, typeof(List<T>));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                Console.WriteLine($"Exception: {e.StackTrace}");
                Log.Error($"Exception: {e.Message}");
                Log.Error($"Exception: {e.StackTrace}");
                return default;
            }

        }

        public void SaveListToFile(ListRepos<T> repos)
        {

            var serializer = new JsonSerializer();
            using StreamWriter fs = new StreamWriter(repos.Path);
            using var jsonTextWriter = new JsonTextWriter(fs);
            serializer.Serialize(fs, repos.Repos);
            Console.WriteLine($"Transport database saved to Repository JSON file at: " + repos.Path);
        }


        public void SaveListToFile(List<T> list, string path)
        {
            var serializer = new JsonSerializer();
            using StreamWriter fs = new StreamWriter(path);
            using var jsonTextWriter = new JsonTextWriter(fs);
            serializer.Serialize(fs, list);
            Console.WriteLine($"Transport database Liet {list} saved to repository JSON file at: " + path);

        }

        public void ClearJSON(string path)
        {
            File.WriteAllText(path, string.Empty);
            Console.WriteLine($"JSON-related file {path} cleared.");

        }

        public void AddTranspInDb(T transport, ListRepos<T> repos)
        {
            if (transport is Transport tr && repos.Repos is List<Transport> lst)
            {
                LoadFileToList(repos);
                repos.Repos.Add(transport);
                SaveListToFile(repos);
                Console.WriteLine($"Transport object {tr.Name} saved to Transport Repository JSON file at: " + repos.Path);
            }
            else Console.WriteLine($"A provided file {repos.Path} in repository {repos.Repos} is not a Transport Repository List or an object {transport} is not a tranposrt and can not be put in the Repository List for JSON.");
        }

        public void DeleteTransp(Guid id, ListRepos<T> repos)
        {
            repos.Repos.Clear();
            LoadFileToList(repos);
            if (repos.Repos is List<Transport> lst)
            {
                bool IsFound = false;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (id == lst[i].Id)
                    {
                        Console.WriteLine($"Delete Transport: object with GUID {id}  is found in database. It's {lst[i].Name}. It will be removed.");
                        IsFound = lst.Remove(lst[i]);
                        SaveListToFile(repos);
                    }
                }
                if (IsFound == false) Console.WriteLine($"Object with GUID {id} is not found.");
            }
            else Console.WriteLine($"A provided file {repos.Path} in repository {repos.Repos} is not a Transport Repository JSON List.");
        }

        public T GetByID(Guid id, ListRepos<T> repos)
        {
            repos.Repos.Clear();
            LoadFileToList(repos);
            Transport transptemp = default;
            if (repos.Repos is List<Transport> lst)
            {
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
                //transptemp = lst.Find(p => p.Id == id);
                //if (transptemp != default)
                //    Console.WriteLine($"GetByID: object with GUID {id}  is found. It's {transptemp.Name}.");
                //else
                //    Console.WriteLine($"Object with GUID {id} is not found.");
            }
            else Console.WriteLine($"A provided file {repos.Path} in repository {repos.Repos} is not a Transport Repository JSON List.");
            return (T)transptemp;
        }

        public void GetTranspInfo(ListRepos<T> repos)
        {
            repos.Repos.Clear();
            LoadFileToList(repos);
            if (repos.Repos is List<Transport> lst)
            {
                Console.WriteLine($"Transport List Info {lst.GetType().Name}:");
                foreach (var item in lst)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine($"A provided file {repos.Path} in repository {repos.Repos} is not a Transport Repository JSON List.");
        }

        public bool UpdateTransp(T transport, ListRepos<T> repos)
        {
            repos.Repos.Clear();
            LoadFileToList(repos);
            if (repos.Repos is List<Transport> lst && transport is Transport transp)
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
                        lst[x] = transport;
                        SaveListToFile(repos);
                        return true;
                    }
                    else throw new TransportNotFoundException($"UpdateTransp. Object with GUID {transp.Id} is not found.");
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
                //        lst[i] = transport;
                //        SaveListToFile(repos);
                //        return true;
                //    }
                //}
                //Console.WriteLine($"Object with GUID {transp.Id} is not found in database.");
                Console.WriteLine("Would you like to add it to the database? Type Y/ N.");
                ContinueVerify(transport, repos);
            }
            else
            {
                Console.WriteLine($"A provided file {repos.Path} is not a Transport Repository JSON List or an object {transport} is not a tranposrt and can not be put in the Repository List.");
            }
            return false;
        }
        void ContinueVerify(T transport, ListRepos<T> repos)
        {
            string? input2 = Console.ReadLine();
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                AddTranspInDb(transport, repos);
        }

    }
}
