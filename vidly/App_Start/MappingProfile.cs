using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using vidly.DTOs;
using vidly.Models;

namespace vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}