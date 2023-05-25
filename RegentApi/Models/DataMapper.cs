using AutoMapper;
using RegentApi.DTO;

namespace RegentApi.Models
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<JobProfile, JobProfileVM>().ReverseMap();          
        }
    }
}
