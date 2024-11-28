using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Application.UseCases.Commands.DrugCommands.UpdateCommand;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.UpdateCommand;

public class UpdateDrugItemCommandHandler(IDrugItemReadRepository drugItemReadRepository,
    IDrugItemWriteRepository drugItemWriteRepository): IRequestHandler<UpdateDrugItemCommand, DrugItem?>
{
    public async Task<DrugItem?> Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await drugItemReadRepository.GetByIdAsync(request.DrugItemId, cancellationToken);
        drugItem.Update(request.DrugId, request.DrugStoreId, request.Cost, request.Count, request.Drug, request.DrugStore);
        await drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);
        return drugItem;
    }
}