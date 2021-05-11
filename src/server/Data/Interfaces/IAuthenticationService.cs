using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Register(string email, string password, AppDbContext dbContext);
    }
}