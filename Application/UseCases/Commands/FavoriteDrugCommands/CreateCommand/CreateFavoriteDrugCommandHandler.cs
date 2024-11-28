using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.CreateCommand;

public class CreateFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository)
    : IRequestHandler<CreateFavoriteDrugCommand, FavoriteDrug>
{
    public async Task<FavoriteDrug> Handle(CreateFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favoriteDrug = new FavoriteDrug(request.Id, request.PersonId, request.Person, request.DrugId, request.Drug, request.DrugStoreId, request.DrugStore);
        await favoriteDrugWriteRepository.AddAsync(favoriteDrug, cancellationToken);
        return favoriteDrug;
    }
}
