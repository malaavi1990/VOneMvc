using System;
using System.Collections.Generic;
using System.Linq;
using VOneBussines.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;
using VOneUtility.Enums;

namespace VOneBussines.Services
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IUnitOfWork _uow = new UnitOfWork();

        public void Save()
        {
            try
            {
                _uow.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Product Category Services
        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            try
            {
                return _uow.ProductCategoryDal.Get(c => c.IsDeleted == false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<ProductCategory> GetAllRootProductCategories()
        {
            try
            {
                return _uow.ProductCategoryDal.Get(c => c.ParentId == null && c.IsDeleted == false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            try
            {
                return _uow.ProductCategoryDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddProductCategory(ProductCategory category)
        {
            try
            {
                _uow.ProductCategoryDal.Insert(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditProductCategory(ProductCategory category)
        {
            try
            {
                _uow.ProductCategoryDal.Update(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteProductCategory(int id)
        {
            try
            {
                _uow.ProductCategoryDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Product Services
        public IEnumerable<Product> GetAllProducts(IsDeletedEnum.IsDeleted isDeleted, int skip, int take)
        {
            try
            {
                if (take == 0 && skip == 0)
                {
                    if (isDeleted == IsDeletedEnum.IsDeleted.All)
                        return _uow.ProductDal.Get();
                    else if (isDeleted == IsDeletedEnum.IsDeleted.OnlyUnDeleted)
                        return _uow.ProductDal.Get(p => p.IsDeleted == false);
                    else
                        return _uow.ProductDal.Get(p => p.IsDeleted == true);
                }
                else
                {
                    if (isDeleted == IsDeletedEnum.IsDeleted.All)
                        return _uow.ProductDal.Get().Skip(skip).Take(take);
                    else if (isDeleted == IsDeletedEnum.IsDeleted.OnlyUnDeleted)
                        return _uow.ProductDal.Get(p => p.IsDeleted == false).Skip(skip).Take(take);
                    else
                        return _uow.ProductDal.Get(p => p.IsDeleted == true).Skip(skip).Take(take);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Product GetProductById(long id)
        {
            try
            {
                return _uow.ProductDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                _uow.ProductDal.Insert(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditProduct(Product product)
        {
            try
            {
                _uow.ProductDal.Update(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteProduct(long id)
        {
            try
            {
                _uow.ProductDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Product Tag Services
        public IEnumerable<ProductTag> GetProductTagsByProductId(long id)
        {
            try
            {
                return _uow.ProductTagDal.Get(t => t.ProductId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddProductTag(ProductTag tag)
        {
            try
            {
                _uow.ProductTagDal.Insert(tag);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteProductTag(long id)
        {
            try
            {
                _uow.ProductTagDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Product Gallery Services
        public IEnumerable<ProductGallery> GetProductGalleriesByProductId(long id)
        {
            try
            {
                return _uow.ProductGalleryDal.Get(g => g.ProductId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ProductGallery GetProductGalleryById(long id)
        {
            try
            {
                return _uow.ProductGalleryDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddProductGallery(ProductGallery gallery)
        {
            try
            {
                _uow.ProductGalleryDal.Insert(gallery);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditProductGallery(ProductGallery gallery)
        {
            try
            {
                _uow.ProductGalleryDal.Update(gallery);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteProductGallery(long id)
        {
            try
            {
                _uow.ProductGalleryDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
