using Data.Enums;

namespace Service.Services.TimeCapsules;

public class CreateTimeCapsuleDto
{
    public string Titile { get; set; }
    public string Description { get; set; }
    public Types Type { get; set; }
    public List<string> AttachmentUrls { get; set; }
    public DateTime OpenedAt { get; set; }
}