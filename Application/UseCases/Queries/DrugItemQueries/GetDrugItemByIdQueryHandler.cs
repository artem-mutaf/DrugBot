using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries;

public class GetDrugItemByIdQueryHandler(IDrugItemReadRepository drugItemReadRepository) : IRequestHandler<GetDrugItemByIdQuery, DrugItem?>
{
    public async Task<DrugItem?> Handle(GetDrugItemByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return response;
    }
}