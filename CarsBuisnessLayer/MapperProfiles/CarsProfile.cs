using AutoMapper;
using CarsBuisnessLayer.DTOs;
using CarsCore.Models;
using System;

namespace CarsBuisnessLayer.MapperProfiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<CarDTO, Car>()
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(x => x.ReleasDate, opt => opt.MapFrom(src => src.ReleasDate))
                .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(x => x.Weight, opt => opt.MapFrom(src => src.Weigth))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Color, opt => opt.MapFrom(src => ToColor(src.Color)))
                .ForMember(x => x.CarBody, opt => opt.MapFrom(src => ToCarBody(src.CarBody)));
        }

        private Color ToColor(string color)
        {
            if (Enum.TryParse(typeof(Color), color, out var result))
            {
                return (Color)result;
            }

            return default;
        }

        private CarBody ToCarBody(string carBody)
        {
            if (Enum.TryParse(typeof(CarBody), carBody, out var result))
            {
                return (CarBody)result;
            }

            return default;
        }
    }
}
