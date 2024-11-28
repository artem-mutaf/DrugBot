using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

public class GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreReadRepository) : IRequestHandler<GetDrugStoreByIdQuery, DrugStore?>
{
    public async Task<DrugStore?> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return response;
    }
}