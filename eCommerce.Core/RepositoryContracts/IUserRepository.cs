using eCommerce.Core.Entity;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// Contract to be implementd by UserRepository that contains data access logic of Users data store
/// </summary>
public interface IUserRepository
{
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);

    Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password);

}
