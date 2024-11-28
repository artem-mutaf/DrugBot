using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.UpdateCommand;

public record UpdateFavoriteDrugCommand(
    Guid FavoriteDrugId,
    Guid Id,
    Guid PersonId,
    Person Person,
    Guid DrugId,
    Drug Drug,
    Guid? DrugStoreId,
    DrugStore? DrugStore) : IRequest<FavoriteDrug>;
