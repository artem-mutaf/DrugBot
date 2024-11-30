using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class СountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        //Настройка таблицы
        builder.ToTable(nameof(Country));

        //Настройка первичного ключа
        builder.HasKey(x => x.Id);

        //Настройка свойства Name
        builder.Property(x => x.Name)
            .IsRequired() 
            .HasMaxLength(100) 
            .HasDefaultValue("Неизвестно"); 

        //Настройка свойства Code
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(10)
            .HasDefaultValue("000");
    }
}