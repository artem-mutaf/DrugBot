using Microsoft.AspNetCore.OData.Query;

namespace Application.Interfaces.Repositories;

public interface IReadRepository<T> where T : class
{
    public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<IQueryable> GetQuaryableAsync(ODataQueryOptions<T> queryOptions,CancellationToken cancellationToken = default);
}