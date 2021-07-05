using LibraryAppBackend.Entities;

namespace LibraryAppBackend.Business.Interfaces
{
    public interface IEditorialBusiness : IBusiness<Editorial>
    {
        int GetNumberBooksRegistered(long editorialId);
    }
}
