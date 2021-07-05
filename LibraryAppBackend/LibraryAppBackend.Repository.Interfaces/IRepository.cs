namespace LibraryAppBackend.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(long id);

        void Save(T entity);
    }
}