using DrugsBot.Interface;

namespace DrugsBot.DomainEvents;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public sealed class DomainItemUpdatedEvent : IDomainEvent
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid DrugItemId { get; set; }
    /// <summary>
    /// Старое кол-во
    /// </summary>
    public double OldCount { get; }
    /// <summary>
    /// Новое кол-во
    /// </summary>
    public double NewCount { get; }
    /// <summary>
    /// Причина
    /// </summary>
    public string Reason { get; }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemId">Уникальный идентификатор</param>
    /// <param name="oldCount">Старое кол-во</param>
    /// <param name="newCount">Новое кол-во</param>
    /// <param name="reason">Причина</param>
    internal DomainItemUpdatedEvent(Guid drugItemId, double oldCount, double newCount, string reason)
    {
        DrugItemId = drugItemId;
        OldCount = oldCount;
        NewCount = newCount;
        Reason = reason;
    }
    
}


