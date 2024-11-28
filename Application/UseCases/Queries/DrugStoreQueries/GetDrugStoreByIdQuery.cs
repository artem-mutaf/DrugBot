using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

public record GetDrugStoreByIdQuery(Guid Id) : IRequest<DrugStore>;
