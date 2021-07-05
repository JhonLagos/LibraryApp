using LibraryAppBackend.Entities;
using LibraryAppBackend.Repository.Interfaces;
using System;

namespace LibraryAppBackend.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryAppContext _context;

        public AuthorRepository(LibraryAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Author GetById(long id)
        {
            return _context.Authors.Find(id);
        }

        public void Save(Author author)
        {
            if (author.Id == 0)
                _context.Authors.Add(author);
            else
                _context.Authors.Update(author);

            _context.SaveChanges();
        }
    }
}
