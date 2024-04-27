using Riok.Mapperly.Abstractions;
using Service.Services.TimeCapsules;
using WebApi.Models.TimeCapsules;

namespace WebApi.Mappers;

[Mapper]
public partial class TimeCapsuleMapper
{
    public partial CreateTimeCapsuleDto CreateTimeCapsuleModelToCreateTimeCapsuleDto(CreateTimeCapsuleModel model);
}