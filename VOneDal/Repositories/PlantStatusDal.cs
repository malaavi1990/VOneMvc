using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class PlantStatusDal : GenericDal<PlantStatus>, IPlantStatusDal
    {
        public PlantStatusDal(DataContext context) : base(context)
        {
        }
    }
}
