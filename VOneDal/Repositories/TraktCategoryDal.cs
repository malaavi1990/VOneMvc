using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class TraktCategoryDal : GenericDal<TraktCategory>, ITraktCategoryDal
    {
        public TraktCategoryDal(DataContext context) : base(context)
        {
        }
    }
}
