using AutoMapper;

namespace VeryIntelligentName.Services.Mapping
{

    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
