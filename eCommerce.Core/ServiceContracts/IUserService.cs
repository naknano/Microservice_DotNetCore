using eCommerce.Core.DTO;
using eCommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest login);

    Task<AuthenticationResponse?> Register(RegisterRequest register);
}
