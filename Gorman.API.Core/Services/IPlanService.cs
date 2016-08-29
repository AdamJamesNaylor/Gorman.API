
namespace Gorman.API.Core.Services
{
    using Domain;

    public interface IPlanService {
        int Add(Plan plan);
        void Update(Plan plan);
    }
}