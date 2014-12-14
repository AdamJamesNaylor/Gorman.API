
namespace AJN.Gorman.API
{
    using Models.Convertors;
    using AutoMapper;

    public static class AutoMapperConfig
    {
        public static void RegisterMappings() {
            Mapper.AddProfile<PhaseProfile>();
        }
    }
}