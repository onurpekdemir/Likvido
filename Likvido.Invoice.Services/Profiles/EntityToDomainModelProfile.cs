using AutoMapper;
using Likvido.Invoice.Entities;
using Likvido.Invoice.Services.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.Services.Profiles
{

    public class EntityToDomainModelProfile : Profile
    {
        public EntityToDomainModelProfile()
        {
            CreateMap<Country, CountryDomainModel>();

        }
    }
}
