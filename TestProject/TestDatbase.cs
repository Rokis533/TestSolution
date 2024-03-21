using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Models;
using TestSolution.Repository;
using TestSolution;

namespace TestProject
{
    [TestClass]
    public class TestDatbase
    {
        private BookStoreContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookStoreContext>()
                .UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=temp_TestDB;Trusted_Connection=True")
                .Options;


            _context = new BookStoreContext(options);

            _context.Database.EnsureCreated();

            //seed
            _context.Books.Add(new Book() { Author = "John", Title = "No name" });
            _context.SaveChanges();
        }
        [TestCleanup]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }



        [TestMethod]
        public void TestDatabaseSchema()
        {
            var model = _context.Model;
            Assert.IsNotNull(model.FindEntityType(typeof(Book))); //for table

            var entityType = model.FindEntityType(typeof(Book));
            Assert.IsNotNull(entityType.FindProperty(nameof(Book.Author))); //for column
        }

    }
}
