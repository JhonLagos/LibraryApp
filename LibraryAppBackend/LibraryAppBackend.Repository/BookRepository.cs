using LibraryAppBackend.Entities;
using LibraryAppBackend.Repository.Interfaces;
using System;

namespace LibraryAppBackend.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryAppContext _context;

        public BookRepository(LibraryAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Book GetById(long id)
        {
            return _context.Books.Find(id);
        }

        public void Save(Book book)
        {
            if (book.Id == 0)
                _context.Books.Add(book);
            else
                _context.Books.Update(book);

            _context.SaveChanges();
        }
    }
}
