using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class TraktTypeDal : GenericDal<TraktType>, ITraktTypeDal
    {
        public TraktTypeDal(DataContext context) : base(context)
        {
        }
    }
}
