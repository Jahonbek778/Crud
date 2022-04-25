using AutoMapper;

namespace Crud
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Model, ModelDto>().ReverseMap();  
        }
    }
}
