using Business.Models;
using System;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Interfaces.Auth
{
    public interface ITokenService
    {
        (string, DateTime?) GenerateToken(UserModel user);
    }
}