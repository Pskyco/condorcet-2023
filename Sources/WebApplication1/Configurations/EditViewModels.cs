using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class EditViewModelsAutoMapperConfigurations : Profile
{
    public EditViewModelsAutoMapperConfigurations()
    {
        CreateMap<PcrTest, PcrTestEditViewModel>()
            .ReverseMap();
    }
}