using System;
namespace Lection21Program1.AuthorizationModel
{
    public interface IUserAuthenticationService
    {
        UserModel Authenticate(LoginModel model);
    }
}

