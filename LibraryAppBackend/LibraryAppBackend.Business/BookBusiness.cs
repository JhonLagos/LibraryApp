using LibraryAppBackend.Business.Interfaces;
using LibraryAppBackend.Entities;
using LibraryAppBackend.Repository.Interfaces;
using LibraryAppBackend.Transversal.Response;
using System;
using System.Net;

namespace LibraryAppBackend.Business
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _repository;
        private readonly IEditorialBusiness _editorialBusiness;
        private readonly IAuthorBusiness _authorBusiness;

        public BookBusiness(IBookRepository repository, IEditorialBusiness editorialBusiness, IAuthorBusiness authorBusiness)
        {
            _repository = repository;
            _editorialBusiness = editorialBusiness;
            _authorBusiness = authorBusiness;
        }

        public Book GetById(long id)
        {
            return _repository.GetById(id);
        }

        public ResultWrapper Save(Book entity)
        {
            try
            {
                var author = _authorBusiness.GetById(entity.AuthorId);
                if (author == null)
                    return new ResultWrapper(HttpStatusCode.BadRequest, "El autor no está registrado");

                var editorial = _editorialBusiness.GetById(entity.EditorialId);
                if (editorial == null)
                    return new ResultWrapper(HttpStatusCode.BadRequest, "La editorial no está registrada");

                if (editorial.MaximumBooksRegister != -1)
                {
                    var numberBooksRegistered = _editorialBusiness.GetNumberBooksRegistered(entity.EditorialId);
                    if (numberBooksRegistered >= editorial.MaximumBooksRegister)
                        return new ResultWrapper(HttpStatusCode.BadRequest, "No es posible registrar el libro, se alcanzó el máximo permitido.");
                }

                _repository.Save(entity);
                return new ResultWrapper<Book>() { Result = entity };
            }
            catch (Exception ex)
            {
                return new ResultWrapper(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
