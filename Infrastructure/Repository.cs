using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot, IBaseEntity
{
    private readonly PhoneBookDbContext _dbContext;

    private readonly DbSet<TEntity> _dbSet;


    public Repository(PhoneBookDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }


    public async Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<IList<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> GetBySpecAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var entity = await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException();
        }

        return entity;
    }

    public async Task RemoveAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet
                          .AsNoTracking()
                          .Where(p => p.Id == id)
                          .FirstOrDefaultAsync(cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException();
        }

        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
    {
        return SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), spec);
    }
}
