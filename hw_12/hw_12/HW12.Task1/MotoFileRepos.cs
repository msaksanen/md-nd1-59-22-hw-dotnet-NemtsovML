using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Task1
{
    public class MotoFileRepos //Reposirory List
    {
        public List<Moto> Repos { get; set; } = new List<Moto>(25);

        string _path = @"D:\user.json";

        public string Path
        {
            get { return _path; }

            set
            {
                if (value.Equals(string.Empty, StringComparison.OrdinalIgnoreCase))
                    Console.WriteLine("Input correct file name with path. Empty field is prohibited.");
                else _path = value;
            }
        }
    }
}
