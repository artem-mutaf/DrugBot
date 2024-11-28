using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.UpdateCommand;

public class UpdateFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository,
    IFavoriteDrugReadRepository favoriteDrugReadRepository): IRequestHandler<UpdateFavoriteDrugCommand, FavoriteDrug>
{
    public async Task<FavoriteDrug> Handle(UpdateFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favoriteDrug = await favoriteDrugReadRepository.GetByIdAsync(request.FavoriteDrugId, cancellationToken);
        favoriteDrug.Update(request.PersonId, request.Person, request.DrugId, request.Drug, request.DrugStoreId, request.DrugStore);
        await favoriteDrugWriteRepository.UpdateAsync(favoriteDrug, cancellationToken);
        return favoriteDrug;
    }
}