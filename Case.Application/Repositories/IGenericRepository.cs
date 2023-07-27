using System.Linq.Expressions;
using Case.Domain.Common;

namespace Case.Application.Repositories;

public interface IGenericRepository<T,TDto> where T : BaseModel
{
    Task<bool> CreateAsync(TDto model);
    Task<bool> UpdateAsync(TDto model);
    Task<bool> RemoveAsync(TDto model);
    Task<List<TDto>> GetListAsync(Expression<Func<T, bool>> query);
    Task<List<TDto>> GetListAsync();
    Task<TDto> GetAsync(Guid id);
    Task<TDto> GetAsync(Expression<Func<T, bool>> query);
}