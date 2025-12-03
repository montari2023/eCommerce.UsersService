using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.SeriviceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _repository;
    private readonly IMapper _mapper;
    public UsersService(IUsersRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> LoginRequest(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _repository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user is null)
        {
            return null;
        }
        return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true ,Token="token"};
    }
    public async Task<AuthenticationResponse?> RegisterRequest(RegisterRequest registerRequest)
    {
        ApplicationUser? user = new ApplicationUser
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName,
            Gender = registerRequest.Gender.ToString()
        };
        var registredUser = await _repository.AddUser(user);
        if (registredUser is null)
        {
            return null;
        }
        return _mapper.Map<AuthenticationResponse>(registredUser) with { Sucess = true,Token="token" };
    }
}
