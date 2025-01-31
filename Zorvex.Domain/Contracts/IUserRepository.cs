using Zorvex.Domain.Entities;

namespace Zorvex.Domain.Contracts;
public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    //Task<User?> GetByEmailAsync(string email);
    Task<Guid> CreateAsync(User user);
}
