using DrugsBot.DomainEvents;

namespace Domain.Entities;
using DrugsBot.Validators;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Связь между препаратом и аптекой
/// </summary>
public class DrugItem : BaseEntity<DrugItem>
{
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, double count, Drug drug, DrugStore drugStore)
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
    public double Count { get; private set; }
        
    // Навигационные свойства
    public Drug Drug { get; private set; }
    public DrugStore DrugStore { get; private set; }

    public void Update(Guid drugId, Guid drugStoreId, decimal cost, double count, Drug drug, DrugStore drugStore)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;
    }
    
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
    /// <summary>
    /// Доменное событие на обновление количества товара
    /// </summary>
    /// <param name="count"></param>
    public void UpdateDrugCount(double newCount, string reason)
    {
        //Валидация для новых данных
        if (newCount < 0)
            throw new InvalidOperationException("Количество не может быть отрицательным");

        if (newCount == Count)
            throw new InvalidOperationException("Количество не изменилось");
        
        if (newCount != Count)
        {
            var oldCount = Count;
            Count = newCount;
            AddDomainEvent(new DomainItemUpdatedEvent(Id, oldCount, newCount, reason));
            
        }
        
        Validate();
    }
}