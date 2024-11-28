using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.CreateCommand;

public class CreateCountryCommandHandler(ICountryWriteRepository countryWriteRepository): IRequestHandler<CreateCountryCommand, Country>
{
    public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country(request.Name, request.Code);
        await countryWriteRepository.AddAsync(country, cancellationToken);
        return country;
    }
}