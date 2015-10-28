using AJN.Gorman.Domain;

namespace AJN.Gorman.API.Core.Services
{
    public interface IPlanService {
        int Add(Plan plan);
        void Update(Plan plan);
    }
}