using System.Windows.Input;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.DeleteCommand;

public record DeleteCountryCommand(Guid CountryId) : IRequest;
