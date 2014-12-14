
namespace AJN.Gorman.API.Models.Convertors
{
    using System.Collections.Generic;
    using Domain;
    using AutoMapper;

    public class PhaseProfile
        : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Phase, PhaseAddPostModel>();
            Mapper.CreateMap<IEnumerable<Phase>, PhaseListGetModel>();
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }
}