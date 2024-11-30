using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // Настройка таблицы
        builder.ToTable(nameof(Person));

        // Настройка первичного ключа
        builder.HasKey(x => x.Id); 

        // Настройка свойств
        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .IsRequired() 
            .HasMaxLength(100); 

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Age)
            .IsRequired() 
            .HasDefaultValue(18);
        
    }
}