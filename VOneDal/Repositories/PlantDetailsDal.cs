using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class PlantDetailsDal : GenericDal<PlantDetails>, IPlantDetailsDal
    {
        public PlantDetailsDal(DataContext context) : base(context)
        {
        }
    }
}
