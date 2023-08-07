using KMS.Domain;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.GenericEF
{
    public interface IGenericEFRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T? GetById(Guid id);
        bool Add(T entity);
        bool Update(T entity);
        bool UpdateById(T entity, Guid id);
        bool DeleteById(T entity, Guid id);
        bool Delete(T entity);
    }
}
