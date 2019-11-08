using AutoMapper;
using DomainModels;
using System;
using ViewModels;

public class CustomProfile:Profile
{
	public CustomProfile()
	{
        CreateMap<Movie, MovieViewModel>();
	}

}
