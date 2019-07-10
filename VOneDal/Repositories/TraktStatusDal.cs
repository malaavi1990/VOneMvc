using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class TraktStatusDal : GenericDal<TraktStatus>, ITraktStatusDal
    {
        public TraktStatusDal(DataContext context) : base(context)
        {
        }
    }
}
