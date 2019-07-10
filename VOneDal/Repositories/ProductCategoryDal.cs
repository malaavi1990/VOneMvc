using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class ProductCategoryDal : GenericDal<ProductCategory>, IProductCategoryDal
    {
        public ProductCategoryDal(DataContext context) : base(context)
        {
        }
    }
}
