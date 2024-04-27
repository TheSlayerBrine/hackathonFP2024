using Data.Entities;

namespace Service.Services.TimeCapsules;

public interface ITimeCapsuleService
{
  public TimeCapsuleDto GetById(int id);
  public List<Attachment> GetAttachments(int id);
  public void CreateTimeCapsule(CreateTimeCapsuleDto dto);
  public void UpdateTimeCapsule(int id, int userId, List<string> attachments);
  public void CloseTimeCapsule(int id, int userId);
  
}