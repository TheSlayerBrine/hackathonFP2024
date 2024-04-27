using Data.Entities;
using Data.Enums;
using Service.Services.Attachments;

namespace Service.Services.TimeCapsules;

public class CreateTimeCapsuleDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Types Type { get; set; }
    public IEnumerable<Attachment> Attachments { get; set; }
    public DateTime OpenedAt { get; set; }
    
}