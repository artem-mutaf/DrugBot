using Application.Interfaces.Repositories.Write;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.DeleteCommand;

public class DeleteDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository): IRequestHandler<DeleteDrugStoreCommand>
{
    public async Task Handle(DeleteDrugStoreCommand request, CancellationToken cancellationToken)
    {
        await drugStoreWriteRepository.DeleteAsync(request.DrugStoreId, cancellationToken);
    }
}