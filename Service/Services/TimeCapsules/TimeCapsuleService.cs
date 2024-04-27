using Data.Entities;
using Data.Infrastructure.UnitOfWork;
using Service.Exceptions;
using Service.Mappers;
using Service.Services.Attachments;

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
        {
            return timeCapsule.Attachments.ToList();
        }
    }

    public void CreateTimeCapsule(CreateTimeCapsuleDto dto)
    {
        if (dto is null)
        {
            throw new Exception("Parameters are not filled");
        }
        var attachmentListToAddToTimeCapsule = new List<Attachment>();
        foreach (var attachment in dto.Attachments)
        {
            var newAttachment = new Attachment
            {
                Url = attachment,
                TimeCapsuleId = unitOfWork.TimeCapsules.GetAll().Last().Id+ 1
            };
            attachmentListToAddToTimeCapsule.Add(newAttachment);
            unitOfWork.Attachments.Add(newAttachment);
        }
       
        var timeCapsule = new TimeCapsule
        {
            Description = dto.Description,
            Title = dto.Title,
            CreatedAt = DateTime.Now,
            OpenedAt = dto.OpenedAt,
            Type = dto.Type,
            WasOpened = false,
            Attachments = attachmentListToAddToTimeCapsule
        };
        unitOfWork.TimeCapsules.Add(timeCapsule);
        unitOfWork.SaveChanges();
    }
    public void UpdateTimeCapsule(int id, int userId, List<string> attachments)
    {
       
        var timeCapsule = unitOfWork.TimeCapsules.GetById(id);
        if(timeCapsule.IsClosed == true)
        {
            throw new Exception("Time capsule is closed! Wait until the timer ends.");
        }
        var listOfAttachments = timeCapsule.Attachments.ToList();
        foreach(var attachment in attachments)
        {
            var newAttachment = new Attachment
            {
                Url = attachment,
                TimeCapsuleId = unitOfWork.TimeCapsules.GetAll().Last().Id+ 1
            };
            unitOfWork.Attachments.Add(newAttachment);
            listOfAttachments.Add(newAttachment);
        }
        timeCapsule.Attachments = listOfAttachments;
        unitOfWork.TimeCapsules.Update(timeCapsule);
        unitOfWork.SaveChanges();
    }
    
    public void CloseTimeCapsule(int id, int userId)
    {
        var timeCapsule = unitOfWork.TimeCapsules.GetById(id);
        if (timeCapsule.OwnerId != userId)
        {
            throw new Exception("You are not the owner of this time capsule");
        }
        timeCapsule.IsClosed = true;
        unitOfWork.TimeCapsules.Update(timeCapsule);
        unitOfWork.SaveChanges();
    }
   
}