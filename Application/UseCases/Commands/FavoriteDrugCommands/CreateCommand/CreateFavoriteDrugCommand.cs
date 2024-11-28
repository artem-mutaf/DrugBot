using Application.UseCases.Queries.DrugStoreQueries;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.CreateCommand;

public record CreateFavoriteDrugCommand(Guid Id,Guid PersonId, Person Person, Guid DrugId, Drug Drug, Guid? DrugStoreId, DrugStore? DrugStore) : IRequest<FavoriteDrug>;
