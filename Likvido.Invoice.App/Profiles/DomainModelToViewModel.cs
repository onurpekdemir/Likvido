using AutoMapper;
using Likvido.Invoice.Entities;
using Likvido.Invoice.Services.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.Services.Profiles
{

    public class DomainModelToViewModel : Profile
    {
        public DomainModelToViewModel()
        {
            CreateMap<CountryDomainModel, SelectListItem>()
                .ForMember(dest => dest.Selected,
                            src => src.MapFrom(q => q.IsSelected))
                 .ForMember(dest => dest.Text,
                       src => src.MapFrom(q => q.Name))
                 .ForMember(dest => dest.Value,
                       src => src.MapFrom(q => q.Id.ToString())).ReverseMap();

        }
    }
}
