using Dapper;
using Zorvex.Domain.Contracts;
using Zorvex.Domain.Entities;
using Zorvex.Infrastructure.Data;

namespace Zorvex.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly DapperDbContext _context;

    public UserRepository(DapperDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        using var connection = _context.CreateConnection();
        const string sql = "SELECT * FROM Users WHERE Username = @Username";
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
    }

    public async Task<Guid> CreateAsync(User user)
    {
        using var connection = _context.CreateConnection();
        const string sql = @"
            INSERT INTO Users (Id, Username, PasswordHash)
            VALUES (@Id, @Username, @PasswordHash)";

        await connection.ExecuteAsync(sql, user);
        return user.Id;
    }
}
