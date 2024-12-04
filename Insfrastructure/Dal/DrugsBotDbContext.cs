using Domain.Entities;
using Insfrastructure.Dal.Configurations;
using Insfrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Insfrastructure.Dal;

public class DrugsBotDbContext : DbContext
{
    private readonly DBSettings _options;
    public DrugsBotDbContext(IOptions<DBSettings> options)
    {
        _options = options.Value;
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
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_options.ConnectionString, (options) =>
        {
            options.CommandTimeout(_options.CommandTimeout);
        });
    }
}