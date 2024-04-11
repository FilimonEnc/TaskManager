namespace TaskManager.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Путь к иконке пользователя
        /// </summary>
        public string IconPath { get; set; } = string.Empty;
    }
}