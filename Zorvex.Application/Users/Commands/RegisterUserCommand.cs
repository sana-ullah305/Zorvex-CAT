using MediatR;
using Zorvex.Domain.Contracts;
using Zorvex.Domain.Entities;

namespace Zorvex.Application.Users.Commands;
public record RegisterUserCommand(string Username, string Password) : IRequest<Guid>;

// RegisterUserHandler.cs
public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
        if (existingUser != null) throw new InvalidOperationException("User already exists");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        return await _userRepository.CreateAsync(user);
    }
}