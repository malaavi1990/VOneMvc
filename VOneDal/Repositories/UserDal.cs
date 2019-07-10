using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class UserDal : GenericDal<User>, IUserDal
    {
        public UserDal(DataContext context) : base(context)
        {
        }
    }
}
