using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    /// <summary>
    /// FluentApi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        //ДЗ посмотреть какие валидации можно переложить в базу с папки Domain.Validators
        //HasAnnotation(); чтобы он брал аннотацию с комментария 
        //Когда сделаем домашку пушим коммитим от ветки dev создаем ветку mr
        //Ещё изучить ветки
        
    }
}