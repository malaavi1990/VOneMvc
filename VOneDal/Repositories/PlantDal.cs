using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class PlantDal : GenericDal<Plant>, IPlantDal
    {
        public PlantDal(DataContext context) : base(context)
        {
        }
    }
}
