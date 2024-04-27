using Data.Entities;

namespace Service.Services.TimeCapsules;

public interface ITimeCapsuleService
{
  public TimeCapsuleDto GetTimeCapsule(int id);
  public List<Attachment> GetAttachments(int id);
  public void CreateTimeCapsule(CreateTimeCapsuleDto dto);
}