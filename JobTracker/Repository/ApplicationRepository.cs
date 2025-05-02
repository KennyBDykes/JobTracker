

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationRepository: IApplicationRepository
{
    private ApplicationDbContext _context;
    public ApplicationRepository(ApplicationDbContext context)
    {
       _context = context;
    }

    public async Task<IEnumerable<Application>> GetApplicationsByStatus(string status)
    {
       return await _context.Applications.Where(a => a.Status == status).ToListAsync();
    }

    public async Task CreateApplication(Application application)
    {
      await _context.Applications.AddAsync(application);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateApplication(Application app)
    {
       _context.Applications.Update(app);
       await _context.SaveChangesAsync();
    }
     public async Task<Application> GetApplicationById(Guid id)
     {
        return await _context.Applications.Where(x => x.Id == id).FirstOrDefaultAsync();
     }

    public async Task<IEnumerable<Application>> GetApplicationsByUserId(Guid userId)
    {
      return await _context.Applications.Where(x => x.UserId == userId).ToListAsync();
    }


    public async Task<Application> GetApplicationByAppIdAndUserId(Guid id, Guid userId)
    {
        return await _context.Applications.Where(x => x.Id == id && x.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task DeleteApplication(Application application)
    {
       _context.Applications.Remove(application);
        await _context.SaveChangesAsync();
    }
}