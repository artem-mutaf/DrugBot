using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        //Настройка таблицы
        builder.ToTable(nameof(FavoriteDrug));

        //Настройка первичного ключа
        builder.HasKey(x => x.Id);

        //Настройка внешнего ключа для Person
        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Cascade);  //Поведение при удалении,удаляется вместе с Person

        //Настройка внешнего ключа для Drug
        builder.HasOne(x => x.Drug)
            .WithMany()
            .HasForeignKey(x => x.DrugId)
            .OnDelete(DeleteBehavior.Cascade);  // Поведение при удалении,удаляется вместе с Drug

        //Настройка внешнего ключа для DrugStore, который может быть null
        builder.HasOne(x => x.DrugStore)
            .WithMany()
            .HasForeignKey(x => x.DrugStoreId)
            .OnDelete(DeleteBehavior.SetNull)  //Если DrugStore удаляется,поле DrugStoreId становится null
            .IsRequired(false);  //DrugStore не обязательный false

        //Настройка свойств Id который важны для каждой записи
        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.PersonId)
            .IsRequired();

        builder.Property(x => x.DrugId)
            .IsRequired();
    }
}