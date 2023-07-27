using AutoMapper;

namespace Case.Application.AutoMapper;

public sealed class BaseMappingConfig : Profile
{
    private static IMapper _mapper;

    public static IMapper GetConfig()
        => _mapper == null
            ? new MapperConfiguration(c => c.AddProfile(new MappingProfiles())).CreateMapper()
            : _mapper;
}   