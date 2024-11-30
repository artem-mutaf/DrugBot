using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Insfrastructure.Dal.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        //Настройка таблицы
        builder.ToTable(nameof(DrugStore));
    
        //Настройка первичного ключа
        builder.HasKey(x => x.Id);
    
        //Настройка свойства DrugNetwork
        builder.Property(x => x.DrugNetwork)
            .IsRequired()             
            .HasMaxLength(100)        
            .HasDefaultValue("Неизвестно");  
    
        //Настройка свойства Number
        builder.Property(x => x.Number)
            .IsRequired()            
            .HasDefaultValue(1);      
    
        //Настройка связи с сущностью Address
        builder.OwnsOne(x => x.Address, address =>
        {
            //Настройка каждого свойства адреса
            address.Property(a => a.Street)
                .IsRequired()           
                .HasMaxLength(200);     
            address.Property(a => a.City)
                .IsRequired()           
                .HasMaxLength(100);     
            address.Property(a => a.House)
                .IsRequired()
                .HasMaxLength(10);      
        });
    }
}