using Data.Enums;

namespace Data.Entities;

public class TimeCapsule
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? OpenedAt { get; set; }
    public Types Type { get; set; }
    public bool WasOpened { get; set; } = false;
    public bool IsClosed { get; set; } = false; // capsula nu e inchisa deci se pot adauga inca attachements
    public int OwnerId { get; set; }
    public IEnumerable<Attachment> Attachments { get; set; }
    public IEnumerable<Account> Collaborators { get; set; }
}
