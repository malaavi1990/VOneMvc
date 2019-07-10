using VOneDal.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;

namespace VOneDal.Repositories
{
    public class ProductGalleryDal : GenericDal<ProductGallery>, IProductGalleryDal
    {
        public ProductGalleryDal(DataContext context) : base(context)
        {
        }
    }
}
