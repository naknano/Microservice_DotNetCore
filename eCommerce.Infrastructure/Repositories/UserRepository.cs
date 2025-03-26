using eCommerce.Core.DTO;
using eCommerce.Core.Entity;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        return new ApplicationUser()
        {
            UserId =  Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Person Name",
            Gender = GenderOption.Male.ToString()
        };
    }

}
