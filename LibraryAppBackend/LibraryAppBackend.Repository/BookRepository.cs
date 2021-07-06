using LibraryAppBackend.Entities;
using LibraryAppBackend.Repository.Interfaces;
using LibraryAppBackend.Transversal.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Book> Search(BookFilters filters)
        {
            var query = _context.Books.Include("Author").Include("Editorial").AsQueryable();

            if (!string.IsNullOrEmpty(filters.Author))
                query = query.Where(b => (b.Author.Name + " " + b.Author.Surname).Contains(filters.Author));

            if (!string.IsNullOrEmpty(filters.Title))
                query = query.Where(b => b.Title.Contains(filters.Title));

            if (filters.Year != 0)
                query = query.Where(b => b.Year == filters.Year);

            return query.ToList();
        }
    }
}
