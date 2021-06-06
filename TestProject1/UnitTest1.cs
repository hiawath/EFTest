using EFTest.Models;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    public class UnitTest1
    {
        private ITestOutputHelper logger;
        public UnitTest1(ITestOutputHelper logger)
        {
            this.logger = logger;
        }
        [Fact]
        public void TestDbInsert()
        {
            MyDbContext db = new MyDbContext();
            //insert
            Employee emp = new Employee
            {
                Name = "Tom",
                DOB = new DateTime(1999, 5, 10),
                Salary = 5000
            };
            db.Employees.Add(emp);

            db.SaveChanges();

            //
            var emps = db.Employees.Where(p => p.Id>=1);
            foreach (var item in emps)
            {
                logger.WriteLine($"{item.Id} : {item.Name}, {item.DOB}");
            }

            Assert.True(emps.Count<Employee>() > 0);

        }
        [Fact]
        public void TestDbListAll()
        {
            MyDbContext db = new MyDbContext();

            var emps = db.Employees.Where(p => p.Id >= 1);
            foreach (var item in emps)
            {
                logger.WriteLine($"{item.Id}, {item.Name}");
            }
            Assert.True(true);
        }
        [Fact]
        public void TestDbDelete()
        {
            MyDbContext db = new MyDbContext();

            var c = db.Employees.FirstOrDefault(p => p.Name=="Tom");
            if (c == null) return;

            db.Employees.Remove(c);
            //db.Employees.RemoveRange(cList);
            db.SaveChanges();

            var emps = db.Employees.Where(p => p.Id >=1);
            foreach (var item in emps)
            {
                logger.WriteLine($"{item.Id}, {item.Name}, {item.DOB},{item.Salary}");
            }
            Assert.True(true);
        }
        [Fact]
        public void TestDbUpdate()
        {
            MyDbContext db = new MyDbContext();

            var c = db.Employees.FirstOrDefault(p => p.Name == "Tom");
            c.Salary = 100000;
            db.SaveChanges();

            var emps = db.Employees.Where(p => p.Id >= 1);
            foreach (var item in emps)
            {
                logger.WriteLine($"{item.Id}, {item.Name}, {item.DOB},{item.Salary}");
            }
            Assert.True(true);
        }
        [Fact]
        public void TestDbSelect()
        {
            MyDbContext db = new MyDbContext();
            //Error occurred  SingleOrDefault
            //var s = db.Employees.SingleOrDefault(p => p.Name == "Tom");

            var f = db.Employees.FirstOrDefault(p => p.Name == "Tom");
            
            var emps = db.Employees.Where(p => p.Id >= 1).Take(10);

            var range = db.Employees.OrderBy(p => p.Name).ThenBy(p => p.Salary);
            
            
            
            foreach (var item in range)
            {
                logger.WriteLine($"{item.Id}, {item.Name}, {item.DOB},{item.Salary}");
            }
            Assert.True(true);
        }
    }
}
