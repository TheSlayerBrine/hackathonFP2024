using Data.Entities;
using Data.Infrastructure.Context;

namespace Data.Repositories.Attachments;

public class AttachmentRepository : IAttachmentRepository
{
    private readonly IAppDbContext dbContext;

    public AttachmentRepository(IAppDbContext dbContext)
    {
    }
    public IEnumerable<Attachment> GetAll()
    {
        return dbContext.Attachments.ToList();
    }

    public Attachment Find(int id)
    {
     return dbContext.Attachments.Where(x => x.Id == id).FirstOrDefault();
    }

    public void Update(Attachment entity)
    {
      dbContext.Attachments.Update(entity);
    }

    public void Delete(Attachment entity)
    {
       dbContext.Attachments.Remove(entity);
    }

    public void Add(Attachment entity)
    {
       dbContext.Attachments.Add(entity);
    }
}