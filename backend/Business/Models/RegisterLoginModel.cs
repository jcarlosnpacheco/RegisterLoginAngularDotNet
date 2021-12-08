namespace RegisterLoginAPI.Business.Models
{
    public class RegisterLoginModel
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Observation { get; set; }

        public int LoginTypeId { get; set; }

        public string Password { get; set; }
    }
}