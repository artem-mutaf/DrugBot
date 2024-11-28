using Application.Interfaces.Repositories.Write;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.DeleteCommand;

public class DeleteFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository): IRequestHandler<DeleteFavoriteDrugCommand>
{
    public async Task Handle(DeleteFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        await favoriteDrugWriteRepository.DeleteAsync(request.FavoriteDrugId, cancellationToken);
    }
}