using DrugsBot.Interface;

namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
using DrugsBot.Validators;

/// <summary>
/// Базовый класс для всех сущностей домена, обеспечивающий сравнение по идентификатору.
/// </summary>
public abstract class BaseEntity<T> where T : BaseEntity<T>
{
    /// <summary>
    /// Список событий
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = [];
    
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Конструктор по умолчанию, инициализирующий новый уникальный идентификатор.
    /// </summary>
    protected BaseEntity()
    { 
        Id = Guid.NewGuid();
    }
    
    /// <summary>
    /// Добавить доменное событие
    /// </summary>
    /// <param name="domainEvent">Доменное событие</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    /// <summary>
    /// Получение списка доменных событий
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }
    /// <summary>
    /// Очистка доменных событий.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    
    
    /// <summary>
    /// Переопределение метода Equals для сравнения сущностей по идентификатору.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если идентификаторы совпадают; иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is null || obj.GetType() != GetType()) 
            return false;

        var other = (BaseEntity<T>)obj;
        return Id.Equals(other.Id);
    }

    /// <summary>
    /// Переопределение метода GetHashCode, возвращающего хеш-код идентификатора.
    /// </summary>
    /// <returns>Хеш-код идентификатора.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
        
    /// <summary>
    /// Оператор сравнения на равенство по идентификатору.
    /// </summary>
    /// <param name="left">Левая сущность.</param>
    /// <param name="right">Правая сущность.</param>
    /// <returns>True, если идентификаторы равны; иначе False.</returns>
    public static bool operator ==(BaseEntity<T>? left, BaseEntity<T>? right)
    {
        if (left is null)
            return right is null;

        return left.Equals(right);
    }

    /// <summary>
    /// Оператор сравнения на неравенство по идентификатору.
    /// </summary>
    /// <param name="left">Левая сущность.</param>
    /// <param name="right">Правая сущность.</param>
    /// <returns>True, если идентификаторы не равны; иначе False.</returns>
    public static bool operator !=(BaseEntity<T>? left, BaseEntity<T>? right)
    {
        return !(left == right);
    }
    
    
}