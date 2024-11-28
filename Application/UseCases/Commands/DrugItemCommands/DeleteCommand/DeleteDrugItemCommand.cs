using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.DeleteCommand;

public record DeleteDrugItemCommand(Guid DrugItemId): IRequest;
