
namespace Zorvex.Application.Users.Dtos;
public class RegisterUserRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}