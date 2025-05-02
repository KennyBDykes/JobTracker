
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
       _context = context;
    }
    public async Task<User> GetUserByUserAndPassword(string username, string password)
    {
       return await _context.Users.Where(x => x.Username == username && x.PasswordHash == password).FirstOrDefaultAsync();
    }
}
