﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // there is no field "FullAddress" in Company class!
            //CreateMap<Company, CompanyDto>()
            //.ForCtorParam("FullAddress",
            //    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<CompanyForUpdateDto, Company>();

            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        }
    }
}