using Domain.Entities;
using Insfrastructure.Dal.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Insfrastructure.Dal;

public class DrugsBotDbContext : DbContext
{
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options)
    {
        
    }
    /// <summary>
    /// Таблица препаратов
    /// </summary>
    public DbSet<Drug> Drugs { get; set; }
    /// <summary>
    /// Таблица связей препаратов с аптекой
    /// </summary>
    public DbSet<DrugItem> DrugsItems { get; set; }
    /// <summary>
    /// Таблица аптек
    /// </summary>
    public DbSet<DrugStore> DrugsStores { get; set; }
    /// <summary>
    /// Таблица любимых препаратов
    /// </summary>
    public DbSet<FavoriteDrug> FavoriteDrugs { get; set; }
    /// <summary>
    /// Таблица стран
    /// </summary>
    public DbSet<Country> Countries { get; set; }
    /// <summary>
    /// Таблица персон
    /// </summary>
    public DbSet<Person> Persons { get; set; }
    /// <summary>
    /// Таблица профилей
    /// </summary>
    public DbSet<Profile> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new DrugConfiguration());
    }
    
}