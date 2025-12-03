using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System.Data;

namespace eCommerce.Infrastructure.Repositories;

public  class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new unique user ID for the user
        user.UserID = Guid.NewGuid();

        //SQL Query to insert user data into the "Users" table.
        string query = "INSERT INTO \"Users\" (\"UserID\", \"Email\", \"Password\", \"PersonName\", \"Gender\") " +
               "VALUES (@UserID, @Email, @Password, @PersonName, @Gender);";

        //Execute the query using Dapper's ExecuteAsync method.
        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
        if(rowCountAffected == 0)
        {
            return null; // Return null if the insertion failed.
        }
        else
        {
            return user;
        }

    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM \"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var parametres = new { Email = email, Password = password };
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parametres);
        if (user is null) return null;
        return user;
    }
}
