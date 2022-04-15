using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace HW14.Task1.Enitities
{
    public class ApplicationContext<T> : DbContext where T : Transport
    {
        public DbSet<T> TranspSQL => Set<T>();

        public ApplicationContext(DbContextOptions<ApplicationContext<T>> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }

}
