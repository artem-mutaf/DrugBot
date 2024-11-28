using Application.Interfaces.Repositories.Write;
using Application.UseCases.Commands.CountryCommands.CreateCommand;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.DeleteCommand;

public class DeleteCountryCommandHandler(ICountryWriteRepository countryWriteRepository): IRequestHandler<DeleteCountryCommand>
{
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        await countryWriteRepository.DeleteAsync(request.CountryId, cancellationToken);
    }
}