namespace Domain.Entities;

public class Person:BaseEntity<Person>
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }

    public Person(Guid id, string firstName, string lastName, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}