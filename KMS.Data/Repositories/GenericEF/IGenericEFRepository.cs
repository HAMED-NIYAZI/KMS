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
        IQueryable<T>  GetAll();
        Task<T?>  GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> UpdateById(T entity, Guid id);
        Task<bool> DeleteById(T entity, Guid id);
        Task<bool> Delete(T entity);
    }
}
