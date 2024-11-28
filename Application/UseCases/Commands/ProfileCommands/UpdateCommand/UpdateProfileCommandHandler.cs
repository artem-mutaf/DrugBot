using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.UpdateCommand;

public class UpdateProfileCommandHandler(IProfileReadRepository profileReadRepository,
    IProfileWriteRepository profileWriteRepository): IRequestHandler<UpdateProfileCommand, Profile>
{
    public async Task<Profile> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await profileReadRepository.GetByIdAsync(request.PersonId, cancellationToken);
        profile.Update(request.Id, request.ExternalId, request.Email);
        await profileWriteRepository.UpdateAsync(profile, cancellationToken);
        return profile;
    }
}