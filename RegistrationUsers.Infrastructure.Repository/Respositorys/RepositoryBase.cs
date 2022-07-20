using Microsoft.EntityFrameworkCore;
using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.Data;

namespace RegistrationUsers.Infrastructure.Repository.Respositorys
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Base
    {
        private readonly RegistrationUserDBContext _context;

        public RepositoryBase(RegistrationUserDBContext Context)
        {
            _context = Context;
        }

        public async virtual Task<TEntity>Add(TEntity obj)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async virtual Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async virtual Task<TEntity> Update(TEntity obj)
        {
            try
            {                          
                _context.Entry<TEntity>(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async virtual Task Delete(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }


    }
}
