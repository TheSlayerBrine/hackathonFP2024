using Data.Entities;
using Data.Infrastructure.UnitOfWork;
using Service.Exceptions;
using Service.Mappers;

namespace Service.Services.TimeCapsules;

public class TimeCapsuleService : ITimeCapsuleService
{
    private readonly IUnitOfWork unitOfWork;
    
    public TimeCapsuleService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    
    public TimeCapsuleDto GetById(int id)
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

    public void CreateTimeCapsule(CreateTimeCapsuleDto dto)
    {
        if (dto is null)
        {
            throw new Exception("Parameters are not filled");
        }
        unitOfWork.Attachments
        var timeCapsule = new TimeCapsule
        {
            Description = dto.Description,
            Title = dto.Titile,
            CreatedAt = DateTime.Now,
            OpenedAt = dto.OpenedAt,
            Type = dto.Type,
            WasOpened = false,
            Attachments = dto.AttachmentUrls.ToList()
        }
    }
}