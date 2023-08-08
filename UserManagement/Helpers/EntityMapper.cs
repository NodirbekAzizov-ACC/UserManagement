using System;
using AutoMapper;
using UserManagement.Entity.Models;
using UsersManagement.BusinessModels;

namespace UsersManagement.Helpers
{
	public class EntityMapper : Profile
	{
		public EntityMapper()
		{
			CreateMap<UserDto, User>();
		}
	}
}

