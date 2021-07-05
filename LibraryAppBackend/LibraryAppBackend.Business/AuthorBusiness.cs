using LibraryAppBackend.Business.Interfaces;
using LibraryAppBackend.Entities;
using LibraryAppBackend.Repository.Interfaces;
using LibraryAppBackend.Transversal.Response;
using System;
using System.Net;

namespace LibraryAppBackend.Business
{
    public class AuthorBusiness : IAuthorBusiness
    {
        private readonly IAuthorRepository _repository;

        public AuthorBusiness(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public Author GetById(long id)
        {
            return _repository.GetById(id);
        }

        public ResultWrapper Save(Author entity)
        {
            try
            {
                _repository.Save(entity);
                return new ResultWrapper<Author>() { Result = entity };
            }
            catch (Exception ex)
            {
                return new ResultWrapper(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
