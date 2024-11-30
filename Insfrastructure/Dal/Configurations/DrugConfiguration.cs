using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Insfrastructure.Dal.Configurations;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    //метод Configure отвечает за конфигурацию сущности для работы с базой данных в рамках Entity Framework,
    //включая все необходимые ограничения и валидации.
    /// <summary>
    /// FluentApi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        //Настроайка таблицы
        builder.ToTable(nameof(Drug));
        //Настройка первичного ключа
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()//Не может быть null
            .HasMaxLength(100);//Максимальная длина строки
        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(100)
            .HasDefaultValue("Неизвестно");//Значение по умолчанию если не указано
        builder.Property(x => x.CountryCodeId)
            .IsRequired()
            .HasDefaultValue(1);
        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(100)
            .HasDefaultValue("Неизвестно");


        //ДЗ посмотреть какие валидации можно переложить в базу с папки Domain.Validators
        //HasAnnotation(); чтобы он брал аннотацию с комментария 
        //Когда сделаем домашку пушим коммитим от ветки dev создаем ветку mr
        //Ещё изучить ветки

    }
}