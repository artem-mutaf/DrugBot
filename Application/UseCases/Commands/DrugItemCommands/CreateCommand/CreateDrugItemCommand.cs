using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.CreateCommand;

public record CreateDrugItemCommand(Guid DrugId,Guid DrugStoreId,decimal Cost, double Count, Drug Drug, DrugStore DrugStore): IRequest<DrugItem>;
