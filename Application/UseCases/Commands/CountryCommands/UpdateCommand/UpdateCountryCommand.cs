using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.UpdateCommand;

public record UpdateCountryCommand(Guid CountryId, string Code, string Name) : IRequest<Country>;
