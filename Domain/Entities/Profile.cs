using DrugsBot.Validators;

namespace Domain.Entities;

using FluentValidation;

public class Profile : BaseEntity<Profile>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="email"></param>
    /// <param name="externalId"></param>
    /// <param name="id"></param>
    public Profile(string email, string externalId, Guid id)
    {
        Email = email;
        ExternalId = externalId;
        Id = id;
        
        Validate();
    }

    /// <summary>
    /// Guid.NewGuid() - Для создания нового глобального уникального идентификатора
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();
    
    /// <summary>
    /// Идентификатор из телеграмм
    /// </summary>
    public string ExternalId { get; set; }
    
    /// <summary>
    /// Список любимых "препаратов"
    /// </summary>
    public List<FavoriteDrug> FavoriteDrugs { get; set; } = new List<FavoriteDrug>();
    
    /// <summary>
    /// Email для рассылки на почту
    /// </summary>
    public  string Email { get; set; }
    
    private void Validate()
    {
        var validator = new ProfileValidator();
        var res = validator.Validate(this);

        if (!res.IsValid)
        {
            var errors = string.Join(" ", res.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }


}