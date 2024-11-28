using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.UpdateCommand;

public class UpdateDrugStoreCommandHandler(IDrugStoreReadRepository drugStoreReadRepository,
    IDrugStoreWriteRepository drugStoreWriteRepository): IRequestHandler<UpdateDrugStoreCommand, DrugStore?>
{
    public async Task<DrugStore?> Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await drugStoreReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);
        drugStore.Update(request.DrugNetwork, request.Number, request.Address);
        await drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);
        return drugStore;
    }
}