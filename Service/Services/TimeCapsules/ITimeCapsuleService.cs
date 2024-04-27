﻿using Data.Entities;

namespace Service.Services.TimeCapsules;

public interface ITimeCapsuleService
{
  public TimeCapsuleDto GetById(int id);
  public List<Attachment> GetAttachments(int id);
}