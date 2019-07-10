using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VOneBussines.Interfaces;
using VOneDomain.Models;
using VOneMvc.Utilities;
using VOneViewModels;
using static VOneUtility.Enums.IsDeletedEnum;

namespace VOneMvc.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IUserBusiness _userBusiness;
        public ProductController(IProductBusiness productBusiness
        , IUserBusiness userBusiness)
        {
            _productBusiness = productBusiness;
            _userBusiness = userBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProduct()
        {
            IEnumerable<Product> products = _productBusiness.GetAllProducts(IsDeleted.OnlyUnDeleted, 0, 0);
            return PartialView(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = _productBusiness.GetAllProductCategories();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductViewModels productViewModel
        , HttpPostedFileBase image
        , HttpPostedFileBase slider)
        {
            if (ModelState.IsValid)
            {
                string imageName = null;
                if (image != null && image.IsImage())
                {
                    imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("/Content/Image/Product/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Product/" + imageName),
                        Server.MapPath("/Content/Image/Product/Thumbnail/" + imageName));
                }

                string sliderName = null;
                if (slider != null && slider.IsImage())
                {
                    sliderName = Guid.NewGuid().ToString() + Path.GetExtension(slider.FileName);
                    slider.SaveAs(Server.MapPath("/Content/Image/Product/" + sliderName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Product/" + sliderName),
                        Server.MapPath("/Content/Image/Product/Thumbnail/" + sliderName));
                }

                Product product = new Product()
                {
                    CreateDate = DateTime.Now,
                    Description = productViewModel.Description,
                    IsDeleted = false,
                    Text = productViewModel.Text,
                    Title = productViewModel.Title,
                    VisitCount = 0,
                    Price = productViewModel.Price,
                    ProductCategoryId = productViewModel.CategoryId,
                    HaveSlider = productViewModel.HaveSlider,
                    SliderImageUrl = sliderName,
                    ImageUrl = imageName,
                    UserId = _userBusiness.GetAllUsers(IsDeleted.OnlyUnDeleted, 0, 0).First().UserId,
                    ProductStatusId = 1
                };
                _productBusiness.AddProduct(product);
                _productBusiness.Save();

                return RedirectToAction("ListProduct");
            }

            ViewBag.Categories = _productBusiness.GetAllProductCategories();
            return PartialView(productViewModel);
        }

        [HttpGet]
        public ActionResult EditProduct(long id)
        {
            Product product = _productBusiness.GetProductById(id);
            ProductViewModels productViewModels = new ProductViewModels()
            {
                HaveSlider = product.HaveSlider,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.ProductCategoryId,
                Title = product.Title,
                Text = product.Text
            };

            ViewBag.Image = product.ImageUrl;
            ViewBag.Slider = product.SliderImageUrl;
            ViewBag.Categories = _productBusiness.GetAllProductCategories();
            return PartialView(productViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(long id
            , ProductViewModels productViewModels
            , HttpPostedFileBase image
            , HttpPostedFileBase slider)
        {
            if (ModelState.IsValid)
            {
                Product product = _productBusiness.GetProductById(id);
                product.Text = productViewModels.Text;
                product.ProductCategoryId = productViewModels.CategoryId;
                product.HaveSlider = productViewModels.HaveSlider;
                product.Description = productViewModels.Description;
                product.Price = productViewModels.Price;
                product.Title = productViewModels.Title;

                string imageName = null;
                if (image != null && image.IsImage())
                {
                    if (product.ImageUrl != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Product/" + product.ImageUrl));
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Product/Thumbnail/" + product.ImageUrl));
                    }

                    imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("/Content/Image/Product/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Product/" + imageName),
                        Server.MapPath("/Content/Image/Product/Thumbnail/" + imageName));
                    product.ImageUrl = imageName;
                }

                string sliderName = null;
                if (slider != null && slider.IsImage())
                {
                    if (product.SliderImageUrl != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Product/" + product.SliderImageUrl));
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Product/Thumbnail/" + product.SliderImageUrl));
                    }

                    sliderName = Guid.NewGuid().ToString() + Path.GetExtension(slider.FileName);
                    slider.SaveAs(Server.MapPath("/Content/Image/Product/" + sliderName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Product/" + sliderName),
                        Server.MapPath("/Content/Image/Product/Thumbnail/" + sliderName));
                    product.SliderImageUrl = sliderName;
                }

                _productBusiness.EditProduct(product);
                _productBusiness.Save();
                return RedirectToAction("ListProduct");
            }

            ViewBag.Categories = _productBusiness.GetAllProductCategories();
            return PartialView(productViewModels);
        }

        public void DeleteProduct(long id)
        {
            Product product = _productBusiness.GetProductById(id);
            product.IsDeleted = true;
            _productBusiness.EditProduct(product);
            _productBusiness.Save();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult ListCategory()
        {
            IEnumerable<ProductCategory> categories = _productBusiness.GetAllProductCategories();
            return PartialView(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            ViewBag.Categories = _productBusiness.GetAllRootProductCategories();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == 0)
                {
                    category.ParentId = null;
                }
                category.CreateDate = DateTime.Now;
                category.IsDeleted = false;
                _productBusiness.AddProductCategory(category);
                _productBusiness.Save();

                return RedirectToAction("ListCategory");
            }

            ViewBag.Categories = _productBusiness.GetAllRootProductCategories();
            return PartialView(category);
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            ProductCategory category = _productBusiness.GetProductCategoryById(id);
            ViewBag.Categories = _productBusiness.GetAllRootProductCategories();
            return PartialView(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == 0 || category.ParentId == null)
                {
                    category.ParentId = null;
                }
                _productBusiness.EditProductCategory(category);
                _productBusiness.Save();

                return RedirectToAction("ListCategory");
            }

            ViewBag.Categories = _productBusiness.GetAllRootProductCategories();
            return PartialView(category);
        }

        public void DeleteCategory(int id)
        {
            ProductCategory category = _productBusiness.GetProductCategoryById(id);
            category.IsDeleted = true;
            _productBusiness.EditProductCategory(category);
            _productBusiness.Save();
        }

        public ActionResult Gallery(long id)
        {
            return View(id);
        }

        public ActionResult ListGallery(long id)
        {
            IEnumerable<ProductGallery> galleries = _productBusiness.GetProductGalleriesByProductId(id);
            return PartialView(galleries);
        }

        [HttpGet]
        public ActionResult AddGallery()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGallery(long id, string title, HttpPostedFileBase image)
        {
            string imageName = null;
            if (image != null && image.IsImage())
            {
                imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                image.SaveAs(Server.MapPath("/Content/Image/Gallery/" + imageName));
                ImageResizer img = new ImageResizer();
                img.Resize(Server.MapPath("/Content/Image/Gallery/" + imageName),
                    Server.MapPath("/Content/Image/Gallery/Thumbnail/" + imageName));

                ProductGallery gallery = new ProductGallery()
                {
                    CreateDate = DateTime.Now,
                    ImageUrl = imageName,
                    Title = title,
                    ProductId = id
                };
                _productBusiness.AddProductGallery(gallery);
                _productBusiness.Save();

                return RedirectToAction("ListGallery", new { id = id });
            }

            return PartialView();
        }

        [HttpGet]
        public ActionResult EditGallery(long id)
        {
            ProductGallery gallery = _productBusiness.GetProductGalleryById(id);
            return PartialView(gallery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGallery(ProductGallery gallery, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string imageName = null;
                if (image != null && image.IsImage())
                {
                    if (gallery.ImageUrl != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Gallery/" + gallery.ImageUrl));
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Gallery/Thumbnail/" + gallery.ImageUrl));
                    }

                    imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("/Content/Image/Gallery/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Gallery/" + imageName),
                        Server.MapPath("/Content/Image/Gallery/Thumbnail/" + imageName));
                }

                _productBusiness.EditProductGallery(gallery);
                _productBusiness.Save();
                return RedirectToAction("ListGallery", new { id = gallery.ProductId });
            }

            return PartialView(gallery);
        }

        public void DeleteGallery(long id)
        {
            ProductGallery gallery = _productBusiness.GetProductGalleryById(id);

            if (gallery.ImageUrl != null)
            {
                System.IO.File.Delete(Server.MapPath("~/Content/Image/Gallery/" + gallery.ImageUrl));
                System.IO.File.Delete(Server.MapPath("~/Content/Image/Gallery/Thumbnail/" + gallery.ImageUrl));
            }

            _productBusiness.DeleteProductGallery(id);
            _productBusiness.Save();
        }
    }
}