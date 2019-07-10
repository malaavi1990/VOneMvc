using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class ProductDal : GenericDal<Product>, IProductDal
    {
        public ProductDal(DataContext context) : base(context)
        {
        }
    }
}
