using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.PersonCommands.UpdateCommand;

public class UpdatePersonCommandHandler(IPersonReadRepository personReadRepository,
    IPersonWriteRepository personWriteRepository): IRequestHandler<UpdatePersonCommand, Person>
{
    public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await personReadRepository.GetByIdAsync(request.PersonId, cancellationToken);
        person.Update(request.FirstName, request.LastName, request.Age);
        await personWriteRepository.UpdateAsync(person, cancellationToken);
        return person;
    }
}