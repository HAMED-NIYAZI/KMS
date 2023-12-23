using AutoMapper;
using KMS.Application.Dtos.HomePageSettingDto;
using KMS.Application.Dtos.OrganizationDto;
using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.AutoMapperMapping
{
    public class HompageSettingMapping : Profile
    {
        public HompageSettingMapping()
        {
            CreateMap<LoginHomePageSettingDto, HomePageSetting>().ReverseMap();

        }
    }
}
