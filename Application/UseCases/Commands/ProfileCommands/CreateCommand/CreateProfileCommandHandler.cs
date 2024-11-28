using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Application.UseCases.Commands.DrugStoreCommands.CreateCommand;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.CreateCommand;

public class CreateProfileCommandHandler(IProfileWriteRepository profileWriteRepository): IRequestHandler<CreateProfileCommand, Profile>
{
    public async Task<Profile> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = new Profile(request.Email, request.ExternalId, request.Id);
        await profileWriteRepository.AddAsync(profile, cancellationToken);
        return profile;
    }
}