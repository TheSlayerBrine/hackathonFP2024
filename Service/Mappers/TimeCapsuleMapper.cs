using Data.Entities;
using Riok.Mapperly.Abstractions;
using Service.Services.TimeCapsules;

namespace Service.Mappers;

[Mapper]
public partial class TimeCapsuleMapper
{
    public partial TimeCapsuleDto TimeCapsuleToTimeCapsuleDto(TimeCapsule timeCapsule);
}