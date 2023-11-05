using System;
namespace Lection21Program1.AuthorizationModel
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}

