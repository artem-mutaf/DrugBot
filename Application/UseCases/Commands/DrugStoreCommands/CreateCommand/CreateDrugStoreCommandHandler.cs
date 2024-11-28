using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.CreateCommand;

public class CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository): IRequestHandler<CreateDrugStoreCommand, DrugStore>
{
    public async Task<DrugStore> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = new DrugStore(request.DrugNetwork, request.Number, request.Address);
        await drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);
        return drugStore;
    }
}