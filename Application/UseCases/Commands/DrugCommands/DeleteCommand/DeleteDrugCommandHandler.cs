using Application.Interfaces.Repositories.Write;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.DeleteCommand;

public class DeleteDrugCommandHandler(IDrugWriteRepository drugWriteRepository): IRequestHandler<DeleteDrugCommand>
{
    public async Task Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
    {
        await drugWriteRepository.DeleteAsync(request.DrugId, cancellationToken);
    }
}