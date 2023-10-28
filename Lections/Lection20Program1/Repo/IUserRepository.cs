using System;
using Lection20Program1.Dto;
using Microsoft.EntityFrameworkCore;

namespace Lection20Program1.Repo
{
	public interface IUserRepository
	{
		public void AddUser(UserDto user);
        public IEnumerable<UserDto> ListUsers();
        public bool Exists(string email);
        public bool Exists(Guid id);

    }
}

