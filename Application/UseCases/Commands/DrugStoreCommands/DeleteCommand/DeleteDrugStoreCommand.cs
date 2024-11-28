using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.DeleteCommand;

public record DeleteDrugStoreCommand(Guid DrugStoreId): IRequest;
