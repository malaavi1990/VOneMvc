using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class RoleDal : GenericDal<Role>, IRoleDal
    {
        public RoleDal(DataContext context) : base(context)
        {
        }
    }
}
