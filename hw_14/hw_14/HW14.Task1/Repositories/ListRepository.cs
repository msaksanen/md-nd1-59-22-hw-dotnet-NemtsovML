using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14.Task1.Repositories
{
    public class ListRepos<T> //Reposirory List
    {

        //Indexing attempt.
        //List<T>[] listcollect = new List<T>[25];

        //public List<T> this[int index]
        //{
        //    get => listcollect[index];
        //    set => listcollect[index] = value;
        //}
        public List<T> Repos { get; set; } = new List<T>(25);

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
