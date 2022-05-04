using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace HW12.Task1
{
    public class MotoJSONRepos //Load JSON file to Collection List. Save Collection to JSON file.
    {

        public static List<Moto> LoadFileToDb(List<Moto> list, string path)
        {
            using StreamReader file = File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();

            Console.WriteLine($"Moto database is loaded from MotoRepository JSON file at: " + path);
            return (List<Moto>)serializer.Deserialize(file, typeof(List<Moto>));
        }
        public static void SaveDBToFile(List<Moto> list, string path)
        {
            var serializer = new JsonSerializer();
            using StreamWriter fs = new StreamWriter(path);
            using var jsonTextWriter = new JsonTextWriter(fs);
            serializer.Serialize(fs, list);
            Console.WriteLine($"Moto database saved to MotoRepository JSON file at: " + path);
        }
    }
}
