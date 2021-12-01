namespace RegisterLoginAPI.Business.Entity
{
    public class RegisterLogin
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        public int LoginTypeId { get; set; }
    }
}