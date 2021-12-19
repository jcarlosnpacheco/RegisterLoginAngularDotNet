using Business.Entity;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginAPI.Business.Interfaces.Auth;
using RegisterLoginAPI.Business.Interfaces.Queries;
using System.Threading.Tasks;

namespace RegisterLoginAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUserQueries _userQueries;
        private readonly ITokenService _tokenService;

        public HomeController(IUserQueries userQueries, ITokenService tokenService)
        {
            _userQueries = userQueries;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginModel login)
        {
            var userReturned = await _userQueries.GetAsync(login.Username, login.Password);

            if (userReturned == null)
                return NotFound(new { message = "Invalid user credentials" });

            var token = _tokenService.GenerateToken(userReturned);

            // hide password
            login.Password = "";

            return new
            {
                user = login,
                token = token
            };
        }
    }
}