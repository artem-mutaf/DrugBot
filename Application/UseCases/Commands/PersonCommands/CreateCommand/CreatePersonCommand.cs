using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.PersonCommands.CreateCommand;

public record CreatePersonCommand(Guid Id, string FirstName, string LastName, int Age) : IRequest<Person>;
