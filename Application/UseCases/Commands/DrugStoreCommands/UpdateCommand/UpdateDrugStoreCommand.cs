using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.UpdateCommand;

public record UpdateDrugStoreCommand(Guid DrugStoreId,string DrugNetwork, int Number, Address Address) : IRequest<DrugStore>;
