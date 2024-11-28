using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.PersonCommands.CreateCommand;

public class CreatePersonCommandHandler(IPersonWriteRepository personWriteRepository): IRequestHandler<CreatePersonCommand, Person>
{
    public async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person(request.Id, request.FirstName, request.LastName, request.Age);
        await personWriteRepository.AddAsync(person, cancellationToken);
        return person;
    }
}