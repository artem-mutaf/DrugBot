using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.UpdateCommand;

public class UpdateDrugCommandHandler(IDrugWriteRepository drugWriteRepository,
    IDrugReadRepository drugReadRepository): IRequestHandler<UpdateDrugCommand, Drug>
{
    public async Task<Drug?> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        drug.Update(request.Name, request.Manufacturer, request.CountryCodeId, request.Country);
        await drugWriteRepository.UpdateAsync(drug, cancellationToken);
        return drug;
    }
}