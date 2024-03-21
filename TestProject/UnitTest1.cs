using Microsoft.EntityFrameworkCore;
using TestSolution;
using TestSolution.Models;
using TestSolution.Repository;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private BookStoreContext _context;
        private IBookRepository _bookRepository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookStoreContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;


            _context = new BookStoreContext(options);
            _bookRepository = new BookRepository(_context);

            _bookRepository.AddBook(new Book() { Id = 1, Author = "John", Title = "No name" });
        }

        [TestMethod]
        public void GetBook_GetBook_GetsBook()
        {

            var book = _bookRepository.GetBook(1);
            Assert.IsNotNull(book);
        }
        [TestMethod]
        public void UpdateBook_GetBookAndUpdate_GetsBookAndUpdates()
        {
            var book = _bookRepository.GetBook(1);

            book.Author = "Rick Ross";

            _bookRepository.UpdateBook(book);

            var bookUpdated = _bookRepository.GetBook(1);


            Assert.AreEqual(bookUpdated, book);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }
    }
}