using System;
using System.Security.Cryptography;
using System.Text;

namespace Lection21Program1.Repository
{
    public interface IUserRepository
    {
        public void UserAdd(string name, string password, RoleId roleId);
        public RoleId UserCheck(string name, string password);
    }
}

