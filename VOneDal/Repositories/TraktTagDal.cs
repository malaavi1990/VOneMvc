using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class TraktTagDal : GenericDal<TraktTag>, ITraktTagDal
    {
        public TraktTagDal(DataContext context) : base(context)
        {
        }
    }
}
