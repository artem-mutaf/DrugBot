using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        //Настройка таблицы
        builder.ToTable(nameof(DrugItem));
    
        //Настройка первичного ключа
        builder.HasKey(x => x.Id);
    
        //Настройка свойства DrugId
        builder.Property(x => x.DrugId)
            .IsRequired();
    
        //Настройка свойства DrugStoreId
        builder.Property(x => x.DrugStoreId)
            .IsRequired();
    
        //Настройка свойства Cost
        builder.Property(x => x.Cost)
            .IsRequired()
            .HasColumnType("decimal(18,2)")  //Указание точности и масштаба для decimal
            .HasDefaultValue(0.00m);
    
        //Настройка свойства Count
        builder.Property(x => x.Count)
            .IsRequired()
            .HasDefaultValue(0.0);
    
        //Настройка связи с сущностью Drug
        //HasOne потому что для создания связи многие к одному или один к одному
        builder.HasOne(x => x.Drug)
            .WithMany()  //Многие DrugItems могут быть связаны с одним Drug
            .HasForeignKey(x => x.DrugId) //Внешний ключ на DrugId
            .OnDelete(DeleteBehavior.Restrict); //Настройка поведения при удалении,в данном случае запретить удаление

        //Настройка связи с сущностью DrugStore
        builder.HasOne(x => x.DrugStore)
            .WithMany()
            .HasForeignKey(x => x.DrugStoreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}