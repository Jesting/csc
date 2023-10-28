﻿using AutoMapper;

public class MappingProfile:Profile
{
	public MappingProfile() => CreateMap<ClientBook, ClientBookDto>().ReverseMap();
}


