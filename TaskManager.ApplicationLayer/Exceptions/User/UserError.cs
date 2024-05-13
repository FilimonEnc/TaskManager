using TaskManager.ApplicationLayer.Models;

namespace TaskManager.ApplicationLayer.Exceptions.User;

public static class UserError
{
    public static readonly Error UserAllReadyHave = new(
        "User.AllReady",
        "Пользователь уже существует.");

    public static readonly Error UserIncorrect = new(
        "User.Incorrect",
        "Не правильный логин, или пароль");
    
    public static readonly Error UserForbidden = new(
        "User.Forbidden",
        "Ошибка доступа");
}