using QueChulosPerros.Shared.Model;

namespace QueChulosPerros.Server.Authentication
{
    public class UserAccount
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public Branch? Branch { get; set; }
    }
}
