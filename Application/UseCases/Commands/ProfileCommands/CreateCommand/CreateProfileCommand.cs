using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.CreateCommand;

public record CreateProfileCommand(string Email, string ExternalId, Guid Id) : IRequest<Profile>;
