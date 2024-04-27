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

    [HttpPost("createTimeCapsule")]
    public ActionResult<TimeCapsuleModel> CreateTimeCapsule(CreateTimeCapsuleModel model)
    {
        var timeCapsule = new TimeCapsuleMapper().CreateTimeCapsuleModelToCreateTimeCapsuleDto(model);
        timeCapsuleService.CreateTimeCapsule(timeCapsule);
        return Ok();
    }
}