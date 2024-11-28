namespace Domain.Entities;

public class Person:BaseEntity<Person>
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set;}
    public string LastName { get; private set; }
    public int Age { get; private set;}

    public void Update(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public Person(Guid id, string firstName, string lastName, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}