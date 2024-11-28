using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.UpdateCommand;

public record UpdateProfileCommand(Guid PersonId,string Email, string ExternalId, Guid Id) : IRequest<Profile>;
