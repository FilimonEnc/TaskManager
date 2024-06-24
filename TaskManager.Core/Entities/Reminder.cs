namespace TaskManager.Core.Entities;

public class Reminder: BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}