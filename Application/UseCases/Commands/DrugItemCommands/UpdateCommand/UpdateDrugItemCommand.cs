using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.UpdateCommand;

public record UpdateDrugItemCommand(Guid DrugItemId, Guid DrugId,Guid DrugStoreId, decimal Cost, double Count, Drug Drug, DrugStore DrugStore): IRequest<DrugItem>;
