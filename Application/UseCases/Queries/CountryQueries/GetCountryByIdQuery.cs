using Domain.Entities;

namespace Application.UseCases.Queries.CountryQueries;
using MediatR;

public record GetCountryByIdQuery(Guid Id) : IRequest<Country?>;
