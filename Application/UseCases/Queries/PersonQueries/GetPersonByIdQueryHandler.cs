using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.PersonQueries;

public class GetPersonByIdQueryHandler(IPersonReadRepository personReadRepository) : IRequestHandler<GetPersonByIdQuery, Person?>
{
    public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await personReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return response;
    }
}