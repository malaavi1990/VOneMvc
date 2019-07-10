using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class PlantTypeDal : GenericDal<PlantType>, IPlantTypeDal
    {
        public PlantTypeDal(DataContext context) : base(context)
        {
        }
    }
}
