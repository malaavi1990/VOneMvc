using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class ProductTagDal : GenericDal<ProductTag>, IProductTagDal
    {
        public ProductTagDal(DataContext context) : base(context)
        {
        }
    }
}
