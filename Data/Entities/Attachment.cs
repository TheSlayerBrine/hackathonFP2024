namespace Data.Entities;

public class Attachment
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int TimeCapsuleId { get; set; }
    public TimeCapsule TimeCapsule { get; set; }
}