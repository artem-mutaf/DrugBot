using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.PersonCommands.UpdateCommand;

public record UpdatePersonCommand(Guid PersonId, string FirstName, string LastName, int Age) : IRequest<Person>;
