using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.PersonQueries;

public record GetPersonByIdQuery(Guid Id) : IRequest<Person>;
