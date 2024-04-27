using Data.Entities;
using Data.Infrastructure.UnitOfWork;
using Service.Mappers;

namespace Service.Services.TimeCapsules;

public class TimeCapsuleService : ITimeCapsuleService
{
    private readonly IUnitOfWork unitOfWork;
    
    public TimeCapsuleService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    
    public TimeCapsuleDto GetTimeCapsule(int id)
    {
      var timeCapsule = unitOfWork.TimeCapsules.GetById(id);
      var timeCapsuleDto = new TimeCapsuleMapper().TimeCapsuleToTimeCapsuleDto(timeCapsule);
      return timeCapsuleDto;
    }

    public List<Attachment> GetAttachments(int id)
    {
        
        var timeCapsule = unitOfWork.TimeCapsules.GetById(id);
        if(DateTime.UtcNow > timeCapsule.OpenedAt)
        {
            throw new Exception("You can't open this capsule yet");
        }
        else
        return timeCapsule.Attachments.ToList();
    }
    
}