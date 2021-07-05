using LibraryAppBackend.Entities;
using LibraryAppBackend.Repository.Interfaces;
using System;
using System.Linq;

namespace LibraryAppBackend.Repository
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly LibraryAppContext _context;

        public EditorialRepository(LibraryAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Editorial GetById(long id)
        {
            return _context.Editorials.Find(id);
        }

        public void Save(Editorial editorial)
        {
            if (editorial.Id == 0)
                _context.Editorials.Add(editorial);
            else
                _context.Editorials.Update(editorial);

            _context.SaveChanges();
        }

        public int GetNumberBooksRegistered(long editorialId)
        {
            return (from e in _context.Editorials
                    join b in _context.Books on e.Id equals b.EditorialId
                    where e.Id == editorialId
                    select b).Count();
        }
    }
}
