using Data.Entities;
using Data.Enums;

namespace WebApi.Models.TimeCapsules;

public class CreateTimeCapsuleModel
{
    public string Titile { get; set; }
    public string Description { get; set; }
    public Types Type { get; set; }
    public List<string> AttachmentUrls { get; set; }
}