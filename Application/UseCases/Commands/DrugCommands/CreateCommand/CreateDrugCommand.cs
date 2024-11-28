using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.CreateCommand;

public record CreateDrugCommand(string Name, string Manufacturer, string CountryCodeId, Country Country): IRequest<Drug>;
