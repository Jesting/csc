using System;
using AutoMapper;

namespace Lection20Program1.Dto.Map
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(y => y.Id))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(y => y.Email))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(y => y.Name))
				.ForMember(dest => dest.Surname, opts => opts.MapFrom(y => y.FamilyName))
                .ForMember(dest => dest.Registered, opts => opts.Ignore())
                .ForMember(dest => dest.Active, opts => opts.Ignore()).ReverseMap();
            ;
        }
	}
}

