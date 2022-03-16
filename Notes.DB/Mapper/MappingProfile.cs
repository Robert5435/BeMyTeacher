using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace BeMyTeacher.DB.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TutoringAd, ViewModelTutoringAd>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.Calification, opt => opt.MapFrom(src => src.Calification.Name))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.EducationLevel, opt => opt.MapFrom(src => src.EducationLevel.Name))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name));
        }
    }
}
