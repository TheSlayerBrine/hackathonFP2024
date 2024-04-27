using Data.Enums;

namespace Service.Services.TimeCapsules;

public class TimeCapsuleDto
{
    public string Description { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? OpenedAt { get; set; }
    public Types Type { get; set; }
    public bool WasOpened { get; set; } = false;
}