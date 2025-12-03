using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.SeriviceContracts;

public interface IUsersService
{
    Task<AuthenticationResponse?> LoginRequest(LoginRequest loginRequest);
    Task<AuthenticationResponse?> RegisterRequest(RegisterRequest registerRequest);

}
