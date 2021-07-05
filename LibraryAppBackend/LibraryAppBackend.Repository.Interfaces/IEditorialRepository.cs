using LibraryAppBackend.Entities;

namespace LibraryAppBackend.Repository.Interfaces
{
    public interface IEditorialRepository : IRepository<Editorial>
    {
        int GetNumberBooksRegistered(long editorialId);
    }
}
