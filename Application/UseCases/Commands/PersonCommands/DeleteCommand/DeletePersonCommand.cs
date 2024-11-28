using MediatR;

namespace Application.UseCases.Commands.PersonCommands.DeleteCommand;

public record DeletePersonCommand(Guid PersonId) : IRequest;
