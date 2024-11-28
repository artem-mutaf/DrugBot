using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.CreateCommand;

public class CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository): IRequestHandler<CreateDrugCommand, Drug>
{
    public async Task<Drug> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var country = new Drug(request.Name, request.Manufacturer, request.CountryCodeId, request.Country);
        await drugWriteRepository.AddAsync(country, cancellationToken);
        return country;
    }
}