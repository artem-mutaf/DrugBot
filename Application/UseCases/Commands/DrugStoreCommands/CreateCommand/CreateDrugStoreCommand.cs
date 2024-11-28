using System.Windows.Input;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.CreateCommand;

public record CreateDrugStoreCommand(string DrugNetwork, int Number, Address Address) : IRequest<DrugStore>;
