using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries;

public record GetDrugItemByIdQuery(Guid Id) : IRequest<DrugItem?>;