namespace TaskManager.ApplicationLayer.Models
{
    public class ReminderModel : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
