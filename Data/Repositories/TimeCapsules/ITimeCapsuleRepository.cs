using Data.Entities;
using Data.Infrastructure.Repository;

namespace Data.Repositories.TimeCapsules;

public interface ITimeCapsuleRepository : IRepository<TimeCapsule>
{
    public TimeCapsule GetById(int id);
    public TimeCapsule GetByName(string name);
}