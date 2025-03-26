using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Map
{
    class ApplicationUserMappingProfile : Profile 
    {
        public ApplicationUserMappingProfile() 
        {

            // source to destination
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.Success, opt => opt.Ignore())
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }


    }
}
