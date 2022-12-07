using System.Text.RegularExpressions;
using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class ListViewModelsAutoMapperConfigurations : Profile
{
    public ListViewModelsAutoMapperConfigurations()
    {
        CreateMap<PcrTest, PcrTestListViewModel>()
            .ForMember(x => x.Performer, y => y.MapFrom(z => $"{z.Performer.Firstname} {z.Performer.Lastname}"))
            .ForMember(x => x.Comment, y => y.MapFrom(z => Regex.Replace(z.Comment, ".", "*")))
            .ForMember(x => x.Code, y => y.MapFrom(z => $"réf.: {z.Code}"));
        //.ReverseMap();

        //CreateMap<PcrTestListViewModel, PcrTest>();
    }
}