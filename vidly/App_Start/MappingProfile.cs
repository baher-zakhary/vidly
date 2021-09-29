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
            //Mapper.CreateMap<Customer, CustomerDto>().ForMember(m => m.Id, opt => opt.Ignore());
            //Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            //Mapper.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
            //Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            /*
             * https://stackoverflow.com/a/2454385/16662094
             * The Ignore() feature is strictly for members you never map, as these members are also skipped in configuration validation
             * Use the Condition() feature to map the member when the condition is true
             * 
             */

            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.isIdAutoMappingDisabled() == false));

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.isIdAutoMappingDisabled() == false));

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.isIdAutoMappingDisabled() == false));

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.isIdAutoMappingDisabled() == false));

            Mapper.CreateMap<Rental, RentalDto>();

            Mapper.CreateMap<RentalDto, Rental>();

        }
    }
}