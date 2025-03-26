using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entity;
using eCommerce.Core.Map;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Service;

internal class UserService : IUserService
{

    private readonly IUserRepository userRepository;
    private readonly IMapper mapping;

    public UserService(IUserRepository userRepository, IMapper mapping)
    {
        this.userRepository = userRepository;
        this.mapping = mapping;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest login)
    {
        ApplicationUser user = await userRepository.GetUserByEmailAndPasswordAsync(login.Email, login.Password);
        if (user == null) return null;

        return new AuthenticationResponse(
                        user.UserId,
                        user.Email,
                        user.PersonName,
                        user.Gender,
                        "Token",
                         true );
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest register)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Email = register.Email,
            Gender = register.Gender,
            Password = register.Password,
            PersonName = register.Email,
            UserId = Guid.NewGuid()
        };

        ApplicationUser response = await userRepository.AddUserAsync(user);
        if (response == null) return null;

        // with success and token assjgn menual but need declare constrcutor in DTO
        AuthenticationResponse authenticationResponse = mapping.Map<ApplicationUser, AuthenticationResponse>(user) with { Success = true, Token = "token" };


        return new AuthenticationResponse(
                        response.UserId,
                        response.Email,
                        response.PersonName,
                        response.Gender,
                        "Token",
                         true
            );
    }
}
