using LibraryAppBackend.Entities;
using LibraryAppBackend.Transversal.Filters;
using System.Collections.Generic;

namespace LibraryAppBackend.Business.Interfaces
{
    public interface IBookBusiness : IBusiness<Book>
    {
        List<Book> Search(BookFilters filters);
    }
}
