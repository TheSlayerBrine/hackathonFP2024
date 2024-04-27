using Data.Entities;
using Data.Infrastructure.Context;
using Data.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.TimeCapsules;

public class TimeCapsuleRepository : Repository<TimeCapsule>, ITimeCapsuleRepository
{
    private readonly IAppDbContext dbContext;
    
    public TimeCapsuleRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public void Add(TimeCapsule entity)
    {
        dbContext.TimeCapsules.Add(entity);
    }
    public void Delete(TimeCapsule entity)
    {
        dbContext.TimeCapsules.Remove(entity);
    }
    public TimeCapsule Find(int id)
    {
        return dbContext.TimeCapsules.Where(x => x.Id == id).FirstOrDefault();
    }
    public TimeCapsule GetById(int id)
    {
        var TimeCapsule = dbContext.TimeCapsules.FirstOrDefault(x => x.Id == id);
        return TimeCapsule;
    }
    public IEnumerable<TimeCapsule> GetAll()
    {
        return dbContext.TimeCapsules.ToList();
    }

    public TimeCapsule GetByName(string name)
    {
        return dbContext.TimeCapsules.Where(x => x.Title == name).FirstOrDefault();
    }
}