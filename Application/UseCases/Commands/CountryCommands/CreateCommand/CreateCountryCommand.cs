using System.Windows.Input;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.CreateCommand;

public record CreateCountryCommand(string Name, string Code) : IRequest<Country>;
