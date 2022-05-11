using QLPBService.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPBService.Application.Interfaces
{
    public interface ICRUD<R,T> where T : class where R : IBaseRepository<T>
    {
        public Task<IEnumerable<T>> Get();

        public Task<T> Get(int id);

        public Task Put(int id, T entity);

        public Task<T> Post(T entity);

        public Task Delete(int id);
    }

    public abstract class CRUD<R, T> : ICRUD<R, T> where T : class where R : IBaseRepository<T>
    {
        protected readonly R _repository;

        public CRUD(R repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if(entity != null)
            await _repository.DeleteAsync(entity);                  
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _repository.GetByIdAsync(id);              
        }

        public async Task<T> Post(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public abstract Task Put(int id, T entity);     
    }
}

