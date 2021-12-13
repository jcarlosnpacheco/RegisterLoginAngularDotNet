using RegisterLoginAPI.Business.Commands.User;

namespace Business.Entity
{
    public class User
    {
        public User(int id, string username, string password, string role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public void SetUser(UpdateUserCommand command)
        {
            Id = command.Id;
            Username = command.Name;
            Password = command.Password;
            Role = command.Role;
        }
    }
}