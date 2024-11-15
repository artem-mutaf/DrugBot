namespace Domain.Entities;

public class FavoriteDrug : BaseEntity<FavoriteDrug>
{
    /// <summary>
    /// Id любимого препарата
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();
    /// <summary>
    /// Id персоны
    /// </summary>
    public Guid PersonId { get; }
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public Person Person { get; }
    /// <summary>
    /// Id препарата
    /// </summary>
    public Guid DrugId { get; }
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public Drug Drug { get; }
    /// <summary>
    /// Id магазина
    /// </summary>
    public Guid? DrugStoreId { get; }
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public DrugStore DrugStore { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id"></param>
    /// <param name="personId"></param>
    /// <param name="person"></param>
    /// <param name="drugId"></param>
    /// <param name="drug"></param>
    /// <param name="drugStoreId"></param>
    /// <param name="drugStore"></param>
    public FavoriteDrug(Guid id,Guid personId,Person person,Guid drugId, Drug drug,Guid? drugStoreId,DrugStore drugStore)
    {
        Id = id;
        PersonId = personId;
        Person = person;
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
    }
    
    
    
    
    
}