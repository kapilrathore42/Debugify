

namespace Debugify.Application.Profile; 
using AutoMapper;
using Debugify.Application.Commands;
using Debugify.Domain.Entity; // Entity classes

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Define mappings here
        CreateMap<AddDebuggingStepCommand, DebugStepDetails>();
        CreateMap<FeatureNameCommand, FeatureName>().ForMember(dest => dest.Name, s => s.MapFrom(src => src.FeatureName));
    }
}
