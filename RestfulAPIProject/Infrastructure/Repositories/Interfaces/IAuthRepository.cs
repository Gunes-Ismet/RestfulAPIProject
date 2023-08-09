using RestfulAPIProject.Models.Entities.Concrete;

namespace RestfulAPIProject.Infrastructure.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        AppUser Authentication(string userName, string password);
    }
}
