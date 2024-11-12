namespace Domain.Entities;
using DrugsBot.Validators;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Связь между препаратом и аптекой
/// </summary>
public class DrugItem : BaseEntity
{
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count, Drug drug, DrugStore drugStore)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;
        
        Validate();
    }

    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; private set; }
        
    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid DrugStoreId { get; private set; }
        
    /// <summary>
    /// Стоимость препарата в данной аптеке.
    /// </summary>
    public decimal Cost { get; private set; }
        
    /// <summary>
    /// Количество препарата на складе.
    /// </summary>
    public int Count { get; private set; }
        
    // Навигационные свойства
    public Drug Drug { get; private set; }
    public DrugStore DrugStore { get; private set; }
    
    private void Validate()
    {
        var validator = new DrugItemValidator();
        var res = validator.Validate(this);

        if (!res.IsValid)
        {
            var errors = string.Join(" ", res.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}