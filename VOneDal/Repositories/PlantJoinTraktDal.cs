using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class PlantJoinTraktDal : GenericDal<PlantJoinTrakt>, IPlantJoinTraktDal
    {
        public PlantJoinTraktDal(DataContext context) : base(context)
        {
        }
    }
}
