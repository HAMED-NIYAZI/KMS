using Data.Context;
using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.GenericEF
{
    public class GenericEFRepository<T> : IGenericEFRepository<T> where T : BaseEntity
    {
        private readonly KMSContext _context;
        public GenericEFRepository(KMSContext context)
        {
            _context = context;
        }
        public bool Add(T entity)
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = DateTime.Now;

            _context.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteById(T entity, Guid Id)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T? GetById(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public bool Update(T entity)
        {
            if (entity.Id == Guid.Empty) return false;
            entity.LastUpdateDate = DateTime.Now;
            _context.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateById(T entity, Guid id)
        {
            T? findedEntity = GetById(id);
            if (findedEntity != null)
            {
                Update(findedEntity);
                return true;
            }
            return false;

        }
    }
}
