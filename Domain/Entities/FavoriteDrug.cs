namespace Domain.Entities;

public class FavoriteDrug : BaseEntity<FavoriteDrug>
{
    /// <summary>
    /// Id любимого препарата
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>   
    /// Id персоны
    /// </summary>
    public Guid PersonId { get; private set; }
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public Person Person { get; private set; }
    /// <summary>
    /// Id препарата
    /// </summary>
    public Guid DrugId { get; private set; }
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public Drug Drug { get; private set; }
    /// <summary>
    /// Id магазина
    /// </summary>
    public Guid? DrugStoreId { get; private set; }
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public DrugStore? DrugStore { get; private set; }

    public void Update(Guid personId, Person person, Guid drugId, Drug drug, Guid? drugStoreId, DrugStore? drugStore)
    {
        PersonId = personId;
        Person = person;
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
    }

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