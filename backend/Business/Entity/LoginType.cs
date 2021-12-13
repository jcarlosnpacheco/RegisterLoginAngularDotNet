using RegisterLoginAPI.Business.Commands.LoginType;

namespace RegisterLoginAPI.Business.Entity
{
    public class LoginType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public LoginType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetLoginType(UpdateLoginTypeCommand command)
        {
            Id = command.Id;
            Name = command.Name;
        }
    }
}