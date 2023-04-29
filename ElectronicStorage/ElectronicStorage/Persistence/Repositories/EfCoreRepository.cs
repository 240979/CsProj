using ElectronicStorage.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStorage.Persistence.Repositories;

public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity :  EntityBase
    where TContext : DbContext
{
    private readonly TContext _context;
    public EfCoreRepository(TContext context)
    {
        _context = context;
    }
    public async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public async Task<TEntity?> Get(Guid id)
    {
        
        return await _context.Set<TEntity>().FindAsync(id);
    }
    public async Task<TEntity> Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity> Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity?> Delete(Guid id)
    {
        var item = await _context.Set<TEntity>().FindAsync(id);
        if (item == null)
        {
            return item;
        }

        _context.Set<TEntity>().Remove(item);
        await _context.SaveChangesAsync();
        return item;
    }
}