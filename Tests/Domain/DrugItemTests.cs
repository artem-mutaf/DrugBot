using Domain.Entities;
using DrugsBot.DomainEvents;

namespace Tests.Domain;
using Xunit;

public class DrugItemTests
{
    /// <summary>
    /// Обновление кол-ва, когда следует добавлять доменное событие при изменении
    /// </summary>
    [Fact] //атрибут который указывает что это тестовый метод
    public void UpdateCount_ShouldAddDomEvent_WhenCountChanges()
    {
        //Мы создаем новый объект для теста, подготавливаем данные для теста
        var drugItem = new DrugItem(Guid.NewGuid(), Guid.NewGuid(), 13, 233, new Drug(), new DrugStore());
        
        //Шаг в котором мы выполняем действие которое мы тестируем, вызывая ранее добавленный в 
        //DrugItem метод который обновляет кол-во с 233 на 320 и данный метод должен добавить
        //доменное событие если кол-во изменилось
        drugItem.UpdateDrugCount(320, "Обновление кол-ва");
        
        //Данный этап, это этап проверки результатов тестируемого действия
        var domainEvents = drugItem.DomainEvents; //Получение списка доменных событий
        
        Assert.Single(domainEvents);//Проверка, что в списке событий только одно событие
        
        var eventDate = domainEvents[0] as DomainItemUpdatedEvent; //Получаем первое событие из списка и проверяем
        //что оно является событием типа DomainItemUpdatedEvent, которое содержит данные о новом и старом значении кол-ва
        
        Assert.NotNull(eventDate);//Убеждаемся что событие не null
        Assert.Equal(233, eventDate.OldCount); //Проверяем что старое кол-во в событии = 233
        Assert.Equal(320, eventDate.NewCount); //Проверяем что новое кол-во в событии = 320

    }
    /// <summary>
    /// Обновление кол-ва когда не следует добавлять доменное событие при изменении кол-ва
    /// </summary>
    [Fact]
    public void UpdateCount_ShouldNotAddDomEvent_WhenCountChanges()
    {
        var drugItem = new DrugItem(Guid.NewGuid(), Guid.NewGuid(), 13, 233, new Drug(), new DrugStore());
        
        drugItem.UpdateDrugCount(233, "Кол-во осталось прежним");

        var domainEvents = drugItem.DomainEvents;
        Assert.Empty(domainEvents);//Событие не должно добавляться
    }
    
    /// <summary>
    /// Тестирование если кол-во является отрицательным
    /// </summary>
    [Fact]
    public void UpdateCount_ShouldThrowException_WhenCountIsNegative()
    {
        var drugItem = new DrugItem(Guid.NewGuid(), Guid.NewGuid(), 13, 233, new Drug(), new DrugStore());
        
        
        var exception = Assert.Throws<ArgumentException>(() => drugItem.UpdateDrugCount(-10, "Отрицательное число"));
        Assert.Equal("Количество не может быть отрицательным", exception.Message);
    }
}