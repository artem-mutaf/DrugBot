namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
using DrugsBot.Validators;

/// <summary>
/// Справочник стран
/// </summary>
public class Country : BaseEntity<Country>
{
    /// <summary>
    /// Конструктор для инициализации страны с названием и кодом.
    /// </summary>
    /// <param name="name">Название страны.</param>
    /// <param name="code">Код страны.</param>
    public Country(string name, string code)
    {
        Name = name;
        Code = code;
        
        Validate();
    }

    /// <summary>
    /// Название страны.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Код страны (например, ISO-код).
    /// </summary>
    public string Code { get; private set; }

    public void Update(string name, string code)
    {
        Name = name;
        Code = code;
    }
        
    // Навигационное свойство для связи с препаратами
    public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
    
    private void Validate()
    {
        var validator = new CountryValidator();
        var res = validator.Validate(this);

        if (!res.IsValid)
        {
            var errors = string.Join(" ", res.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}