using Data.Enums;

namespace WebApi.Models.TimeCapsules;

public class TimeCapsuleModel
{
    public string Description { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? OpenedAt { get; set; }
    public Types Type { get; set; }
    public bool WasOpened { get; set; } = false;
}