using AutoMapper;
using CandidateManagementAPI.DTOs;
using CandidateManagementAPI.Models;

namespace CandidateManagementAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CandidateDto, Candidate>();
        }
    }

}
