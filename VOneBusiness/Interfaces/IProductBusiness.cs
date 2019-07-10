using System;
using System.Collections.Generic;
using System.Text;
using VOneDomain.Models;
using VOneUtility.Enums;

namespace VOneBussines.Interfaces
{
    public interface IProductBusiness
    {
        // ProductCategory Services
        void Save();
        IEnumerable<ProductCategory> GetAllProductCategories();
        IEnumerable<ProductCategory> GetAllRootProductCategories();
        ProductCategory GetProductCategoryById(int id);
        void AddProductCategory(ProductCategory category);
        void EditProductCategory(ProductCategory category);
        void DeleteProductCategory(int id);

        // Product Services
        IEnumerable<Product> GetAllProducts(IsDeletedEnum.IsDeleted isDeleted, int skip, int take);
        Product GetProductById(long id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(long id);

        // Product Tag Services
        IEnumerable<ProductTag> GetProductTagsByProductId(long id);
        void AddProductTag(ProductTag tag);
        void DeleteProductTag(long id);

        // Product Gallery Services
        IEnumerable<ProductGallery> GetProductGalleriesByProductId(long id);
        ProductGallery GetProductGalleryById(long id);
        void AddProductGallery(ProductGallery gallery);
        void EditProductGallery(ProductGallery gallery);
        void DeleteProductGallery(long id);
    }
}
