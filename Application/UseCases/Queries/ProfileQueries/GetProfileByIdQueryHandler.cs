using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

public class GetProfileByIdQueryHandler(IProfileReadRepository profileReadRepository) : IRequestHandler<GetProfileByIdQuery, Profile?>
{
    public async Task<Profile?> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await profileReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return response;
    }
}