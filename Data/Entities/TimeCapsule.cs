using Data.Enums;

namespace Data.Entities;

public class TimeCapsule
{
    public int Id { get; set; }
    public IEnumerable<Attachment> Attachments { get; set; }
    public Types Type { get; set; }
}