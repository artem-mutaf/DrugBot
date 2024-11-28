using Application.Interfaces.Repositories.Write;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.DeleteCommand;

public class DeleteDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository): IRequestHandler<DeleteDrugItemCommand>
{
    public async Task Handle(DeleteDrugItemCommand request, CancellationToken cancellationToken)
    {
        await drugItemWriteRepository.DeleteAsync(request.DrugItemId, cancellationToken);
    }
}