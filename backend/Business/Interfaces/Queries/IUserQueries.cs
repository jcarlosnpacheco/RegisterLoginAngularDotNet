using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Interfaces.Queries
{
    public interface IUserQueries
    {
        Task<UserModel> GetAsync(string username, string password);
    }
}