using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.DeleteCommand;

public record DeleteFavoriteDrugCommand(Guid FavoriteDrugId) : IRequest;
