using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        //Настройка таблицы
        builder.ToTable(nameof(Profile));

        //Настройка первичного ключа
        builder.HasKey(x => x.Id);

        //Настройка свойств
        builder.Property(x => x.Id)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder.HasIndex(x => x.Email)
            .IsUnique();//Добавляем индекс для оптимизации поиска по Email
        
        builder.Property(x => x.ExternalId)
            .IsRequired() 
            .HasMaxLength(100);
    }
}