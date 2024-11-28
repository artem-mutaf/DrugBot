using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.CreateCommand;

public class CreateDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository): IRequestHandler<CreateDrugItemCommand, DrugItem>
{
    public async Task<DrugItem> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = new DrugItem(request.DrugId,request.DrugStoreId,request.Cost, request.Count, request.Drug, request.DrugStore);
        await drugItemWriteRepository.AddAsync(drugItem, cancellationToken);
        return drugItem;
    }
}