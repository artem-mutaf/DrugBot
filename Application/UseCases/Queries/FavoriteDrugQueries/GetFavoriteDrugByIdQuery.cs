using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavoriteDrugQueries;

public record GetFavoriteDrugByIdQuery(Guid Id) : IRequest<FavoriteDrug>;
