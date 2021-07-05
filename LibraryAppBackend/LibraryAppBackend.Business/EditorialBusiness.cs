using LibraryAppBackend.Business.Interfaces;
using LibraryAppBackend.Entities;
using LibraryAppBackend.Repository.Interfaces;
using LibraryAppBackend.Transversal.Response;
using System;
using System.Net;

namespace LibraryAppBackend.Business
{
    public class EditorialBusiness : IEditorialBusiness
    {
        private readonly IEditorialRepository _repository;

        public EditorialBusiness(IEditorialRepository repository)
        {
            _repository = repository;
        }

        public Editorial GetById(long id)
        {
            return _repository.GetById(id);
        }

        public ResultWrapper Save(Editorial entity)
        {
            try
            {
                if (entity.MaximumBooksRegister <= 0 && entity.MaximumBooksRegister != -1)
                    return new ResultWrapper(HttpStatusCode.BadRequest, "El máximo de libros registrados no es valido. En caso de no existir límite indicar -1");

                _repository.Save(entity);
                return new ResultWrapper<Editorial>() { Result = entity };
            }
            catch (Exception ex)
            {
                return new ResultWrapper(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        public int GetNumberBooksRegistered(long editorialId)
        {
            return _repository.GetNumberBooksRegistered(editorialId);
        }
    }
}
