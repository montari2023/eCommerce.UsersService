using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.RepositoryContracts;

public interface IUsersRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email,string? password);
}
