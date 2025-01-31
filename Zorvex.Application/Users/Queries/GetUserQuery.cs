using MediatR;
using Zorvex.Domain.Contracts;
using Zorvex.Domain.Entities;

namespace Zorvex.Application.Users.Queries;
public record GetUserQuery(string Username) : IRequest<User?>;

// GetUserHandler.cs
public class GetUserHandler : IRequestHandler<GetUserQuery, User?>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByUsernameAsync(request.Username);
    }
}
