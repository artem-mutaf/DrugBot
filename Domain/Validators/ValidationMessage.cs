namespace DrugsBot.Validators;

public static class ValidationMessage
{
    public static string NotNull = "{PropertyName} не может быть равен NULL";
    public static string NotEmpty = "{PropertyName} не может быть пустым";
    public static string WrongLength = "{PropertyName} должен быть от {min} до {max символов";
    public static string InvalidCharacters = "{PropertyName} не должно содержать специальные символы";
    public static string PositiveNumber = "{PropertyName} должно быть положительным числом";
    
}