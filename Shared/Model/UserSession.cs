﻿namespace QueChulosPerros.Shared.Model
{
    public class UserSession
    {
        public string? UserName { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }
        public Branch? Branch { get; set; }

    }
}
