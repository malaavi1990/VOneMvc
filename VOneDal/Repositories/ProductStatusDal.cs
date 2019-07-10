using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class ProductStatusDal : GenericDal<ProductStatus>, IProductStatusDal
    {
        public ProductStatusDal(DataContext context) : base(context)
        {
        }
    }
}
