﻿using AutoMapper;
using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMS.Domain.Dto.Organization;

namespace KMS.Application.Services.AutoMapperService
{

    public class OrganizationMapping : Profile
    {
        public OrganizationMapping()
        {
            CreateMap<OrganizationDto, Organization>().ReverseMap();
            CreateMap<OrganizationTree, Organization>().ReverseMap();
          //  CreateMap(typeof(BaseEntity), typeof(BaseEntity) ).ReverseMap();
            //CreateMap<OrganizationDto, Organization>();
                //.ForMember(dest => dest.HomePageSetting, opt => opt.Ignore())
                //.ForMember(dest=>dest.Parent,opt=>opt.Ignore())
                //.ForMember(dest=>dest.Children,opt=>opt.Ignore());
            //CreateMap<Organization, OrganizationDto>();
                //.ForMember(dest => dest.Parent, opt => opt.Ignore())
               // .ForMember(dest => dest.Children, opt => opt.Ignore()); ;
        }
    }
}
