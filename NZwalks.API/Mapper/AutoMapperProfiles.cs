using AutoMapper;
using NZwalks.API.Models;
using NZwalks.API.Models.DTO;

namespace NZwalks.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<NZwalkRequest,Walk>().ReverseMap();
            CreateMap<NZwalkResponse,Walk>().ReverseMap();
        
        }
        
    }
}
