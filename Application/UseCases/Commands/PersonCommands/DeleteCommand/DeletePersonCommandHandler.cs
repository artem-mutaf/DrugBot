using Application.Interfaces.Repositories.Write;
using Application.UseCases.Commands.PersonCommands.CreateCommand;
using MediatR;

namespace Application.UseCases.Commands.PersonCommands.DeleteCommand;

public class DeletePersonCommandHandler(IPersonWriteRepository personWriteRepository): IRequestHandler<DeletePersonCommand>
{
    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        await personWriteRepository.DeleteAsync(request.PersonId, cancellationToken);
    }
}