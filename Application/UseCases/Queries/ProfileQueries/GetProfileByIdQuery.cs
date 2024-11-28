using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

public record GetProfileByIdQuery(Guid Id) : IRequest<Profile>;
