using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.DeleteCommand;

public record DeleteProfileCommand(Guid ProfileId): IRequest;
