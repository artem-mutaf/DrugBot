using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;

public class GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository) : IRequestHandler<GetCountryByIdQuery, Country?>
{
    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return response;
    }
}