using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.DeleteCommand;

public class DeleteProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    : IRequestHandler<DeleteProfileCommand>
{
    public async Task Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        await profileWriteRepository.DeleteAsync(request.ProfileId, cancellationToken);
    }
}
