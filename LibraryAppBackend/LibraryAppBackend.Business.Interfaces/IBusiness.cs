using LibraryAppBackend.Transversal.Response;

namespace LibraryAppBackend.Business.Interfaces
{
    public interface IBusiness<T> where T : class
    {
        T GetById(long id);

        ResultWrapper Save(T entity);
    }
}
