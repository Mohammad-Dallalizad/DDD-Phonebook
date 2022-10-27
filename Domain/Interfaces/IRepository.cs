using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces;

public interface IRepository<TEntity> where TEntity : class, IAggregateRoot ,IBaseEntity
{
    Task<IList<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

    Task<TEntity> GetBySpecAsync(ISpecification<TEntity> specification ,CancellationToken cancellationToken);

    Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    Task RemoveAsync(int id, CancellationToken cancellationToken);
}
