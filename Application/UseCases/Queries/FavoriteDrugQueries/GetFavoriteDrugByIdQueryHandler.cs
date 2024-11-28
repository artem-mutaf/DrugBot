using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavoriteDrugQueries;

public class GetFavoriteDrugByIdQueryHandler(IFavoriteDrugReadRepository favoriteDrugReadRepository) : IRequestHandler<GetFavoriteDrugByIdQuery, FavoriteDrug?>
{
    public async Task<FavoriteDrug?> Handle(GetFavoriteDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await favoriteDrugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return response;
    }
}