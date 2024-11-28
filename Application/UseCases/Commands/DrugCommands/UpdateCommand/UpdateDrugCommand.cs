using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.UpdateCommand;

public record UpdateDrugCommand(Guid DrugId, string Name, string Manufacturer, string CountryCodeId, Country Country) : IRequest<Drug>;
