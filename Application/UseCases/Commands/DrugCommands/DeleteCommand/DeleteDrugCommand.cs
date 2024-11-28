using MediatR;

namespace Application.UseCases.Commands.DrugCommands.DeleteCommand;

public record DeleteDrugCommand(Guid DrugId): IRequest;
