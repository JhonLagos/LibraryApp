using LibraryAppBackend.Entities;
using LibraryAppBackend.Transversal.Filters;
using System.Collections.Generic;

namespace LibraryAppBackend.Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> Search(BookFilters filters);
    }
}
