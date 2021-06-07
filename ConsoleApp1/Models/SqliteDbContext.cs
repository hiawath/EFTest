using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class SqliteDbContext:DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;;Initial Catalog=MyDB; Integrated Security=SSPI");
            //String interpolation to reach the right path
            //optionsBuilder.UseSqlite($"Data Source=./sqlite.db");
            optionsBuilder.UseSqlite($"Data Source=D:\\Temp\\2021-06\\ConsoleApp1\\ConsoleApp1\\sqlite.db");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
