using System.Linq.Expressions;
using AutoMapper;
using Case.Application.AutoMapper;
using Case.Application.Repositories;
using Case.Domain.Common;
using Case.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Case.Persistance.Repositories;

public class GenericRepository<T,TDto> : IGenericRepository<T,TDto> where T : BaseModel
{
    protected readonly KafeinCaseDataContext _context;
    private readonly IMapper _mapper;

    public GenericRepository(KafeinCaseDataContext context)
    {
        _context = context;
        _mapper = BaseMappingConfig.GetConfig();
    }

    public async Task<TDto> GetAsync(Guid id)
        => _mapper.Map<TDto>(await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsActive));

    public async Task<TDto> GetAsync(Expression<Func<T, bool>> query)
        => _mapper.Map<TDto>(await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(query));
    
    public async Task<List<TDto>> GetListAsync(Expression<Func<T, bool>> query)
        => _mapper.Map<List<TDto>>(await _context.Set<T>().AsNoTracking().Where(query).ToListAsync());

    public async Task<List<TDto>> GetListAsync()
        => _mapper.Map<List<TDto>>(await _context.Set<T>().AsNoTracking().Where(x => x.IsActive).ToListAsync());

    public async Task<bool> CreateAsync(TDto model)
    {
        if (model == null) return false;

        await using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                _context.Entry(_mapper.Map<T>(model)).State = EntityState.Added;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
    public async Task<bool> UpdateAsync(TDto model)
    {
        if (model == null) return false;
        await using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                _context.Entry(_mapper.Map<T>(model)).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
    public async Task<bool> RemoveAsync(TDto model)
    {
        if (model == null) return false;
        await using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                _context.Entry(_mapper.Map<T>(model)).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}