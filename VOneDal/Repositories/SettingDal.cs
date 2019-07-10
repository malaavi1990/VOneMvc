using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class SettingDal : GenericDal<Setting>, ISettingDal
    {
        public SettingDal(DataContext context) : base(context)
        {
        }
    }
}
