using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class TraktDal : GenericDal<Trakt>, ITraktDal
    {
        public TraktDal(DataContext context) : base(context)
        {
        }
    }
}
