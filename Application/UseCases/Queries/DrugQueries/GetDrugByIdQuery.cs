using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

public record GetDrugByIdQuery(Guid Id) : IRequest<Drug>;
