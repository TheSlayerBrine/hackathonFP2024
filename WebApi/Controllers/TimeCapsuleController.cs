using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.TimeCapsules;
using WebApi.Mappers;
using WebApi.Models.TimeCapsules;

namespace WebApi.Controllers;
[ApiController]
[Route("api/timecapsules")]
public class TimeCapsuleController : BaseController
{
    private readonly ITimeCapsuleService timeCapsuleService;

    public TimeCapsuleController(ITimeCapsuleService timeCapsuleService)
    {
        this.timeCapsuleService = timeCapsuleService;
    }
    [AllowAnonymous]
    [HttpPost("createTimeCapsule")]
    public ActionResult<TimeCapsuleModel> CreateTimeCapsule(CreateTimeCapsuleModel model)
    {
  
        var timeCapsule = new TimeCapsuleMapper().CreateTimeCapsuleModelToCreateTimeCapsuleDto(model);
        timeCapsule.OwnerId = UserId.Value;
        timeCapsuleService.CreateTimeCapsule(timeCapsule);
        return Ok();
    }
    [HttpPut("updateTimeCapsule")]
    public ActionResult<TimeCapsuleModel> UpdateTimeCapsule(int CapsuleId, List<string> attachments)
    {
        ValidateUserId();
        var timeCapsule = timeCapsuleService.GetById(CapsuleId);
        if(timeCapsule.OwnerId != UserId.Value)
        {
            return Unauthorized();
        }
        timeCapsuleService.UpdateTimeCapsule(CapsuleId, UserId.Value, attachments);
        return Ok();
    }
    [HttpPut("closeTimeCapsule")]
    public ActionResult<TimeCapsuleModel> CloseTimeCapsule(int CapsuleId)
    {
        ValidateUserId();
        var timeCapsule = timeCapsuleService.GetById(CapsuleId);
        if(timeCapsule.OwnerId != UserId.Value)
        {
            return Unauthorized();
        }
        timeCapsuleService.CloseTimeCapsule(CapsuleId,timeCapsule.OwnerId.Value);
        return Ok();
    }
}