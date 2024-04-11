using Avalonia.Media.Imaging;
using System.Text.Json.Serialization;

namespace TaskManager.Models
{
    public class UserModel : BaseModel
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
        /// Путь к иконке пользователя
        /// </summary>
        public string IconPath { get; set; } = string.Empty;


        //[JsonIgnore]
        //public Image IconUser { get; set; } = null!;
    }
}
