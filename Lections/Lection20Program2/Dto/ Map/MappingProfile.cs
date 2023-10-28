using System;
using AutoMapper;

public class MappingProfile:Profile
{
	public MappingProfile()
	{
        CreateMap<AuthorDto, Author>().ReverseMap();
        CreateMap<BookDto, Book>().ReverseMap();
     
    }
}


