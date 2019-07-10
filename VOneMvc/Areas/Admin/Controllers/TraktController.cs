using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VOneBusiness.Interfaces;
using VOneBussines.Interfaces;
using VOneDomain.Models;
using VOneMvc.Utilities;
using VOneUtility.Enums;
using VOneViewModel;

namespace VOneMvc.Areas.Admin.Controllers
{
    public class TraktController : Controller
    {
        private readonly ITraktBusiness _traktBusiness;
        private readonly IUserBusiness _userBusiness;
        public TraktController(ITraktBusiness traktBusiness
        , IUserBusiness userBusiness)
        {
            _traktBusiness = traktBusiness;
            _userBusiness = userBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTrakt(int page = 1)
        {
            IEnumerable<Trakt> trakts = _traktBusiness.GetAllTrakts(IsDeletedEnum.IsDeleted.OnlyUnDeleted, 0, 0);

            // Paging
            int pageSize = 3;
            ViewBag.PageCount = (trakts.Count() / pageSize) + 1;
            ViewBag.CurentPage = page;

            var data = trakts.Skip(page * pageSize - pageSize).Take(pageSize).ToList();
            return PartialView(data);
        }

        [HttpGet]
        public ActionResult AddTrakt()
        {
             ViewBag.Categories = _traktBusiness.GetAllTraktCategories();
            ViewBag.Types = _traktBusiness.GetAllTraktTypes();
            ViewBag.Status = _traktBusiness.GetAllTraktStatus();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTrakt(TraktViewModels traktViewModel
            , string tags
            , HttpPostedFileBase image
            , HttpPostedFileBase slider)
        {
            if (ModelState.IsValid)
            {
                // Save Index Image To Storage
                string imageName = null;
                if (image != null && image.IsImage())
                {
                    imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("/Content/Image/Trakt/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Trakt/" + imageName),
                        Server.MapPath("/Content/Image/Trakt/Thumbnail/" + imageName));
                }

                // Save Slider Image To Storage
                string sliderName = null;
                if (slider != null && slider.IsImage())
                {
                    sliderName = Guid.NewGuid().ToString() + Path.GetExtension(slider.FileName);
                    slider.SaveAs(Server.MapPath("/Content/Image/Trakt/" + sliderName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Trakt/" + sliderName),
                        Server.MapPath("/Content/Image/Trakt/Thumbnail/" + sliderName));
                }

                // Add Trakt To DataBase
                Trakt trakt = new Trakt()
                {
                    CreateDate = DateTime.Now,
                    Description = traktViewModel.Description,
                    FromDate = traktViewModel.FromDate,
                    HaveSlider = traktViewModel.HaveSlider,
                    IsActive = true,
                    Text = traktViewModel.Text,
                    TraktCategoryId = traktViewModel.TraktCategoryId,
                    TraktTitle = traktViewModel.TraktTitle,
                    ToDate = traktViewModel.ToDate,
                    IsDeleted = false,
                    ImageUrl = imageName,
                    SliderImageUrl = sliderName,
                    VisitCount = 0,
                    TraktStatusId = traktViewModel.TraktStatusId,
                    TraktTypeId = traktViewModel.TraktTypeId
                };
                _traktBusiness.AddTrakt(trakt);
                _traktBusiness.Save();

                // Add Trakt-Tag To DataBase
                _traktBusiness.AddTraktTags(trakt.TraktId, tags);

                return RedirectToAction("ListTrakt");
            }

            ViewBag.Categories = _traktBusiness.GetAllTraktCategories();
            ViewBag.Types = _traktBusiness.GetAllTraktTypes();
            ViewBag.Status = _traktBusiness.GetAllTraktStatus();

            ViewBag.Tags = tags;
            ViewBag.Error = true;
            return PartialView(traktViewModel);
        }

        [HttpGet]
        public ActionResult EditTrakt(long id)
        {
            Trakt trakt = _traktBusiness.GetTraktById(id);
            TraktViewModels traktViewModels = new TraktViewModels()
            {
                TraktCategoryId = trakt.TraktCategoryId,
                Description = trakt.Description,
                HaveSlider = trakt.HaveSlider,
                Text = trakt.Text,
                TraktTitle = trakt.TraktTitle,
                TraktStatusId = trakt.TraktStatusId,
                TraktTypeId = trakt.TraktTypeId,
                FromDate = trakt.FromDate
            };

            string tags = "";
            if (trakt.TraktTags.Any())
            {
                tags = _traktBusiness.GetStringTagsByTraktId(trakt.TraktId);
            }

            ViewBag.Image = trakt.ImageUrl;
            ViewBag.Slider = trakt.SliderImageUrl;
            ViewBag.Categories = _traktBusiness.GetAllTraktCategories();
            ViewBag.Types = _traktBusiness.GetAllTraktTypes();
            ViewBag.Status = _traktBusiness.GetAllTraktStatus();

            ViewBag.Tags = tags;
            return PartialView(traktViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTrakt(long id
            , TraktViewModels traktViewModels
            , string tags
            , HttpPostedFileBase image
            , HttpPostedFileBase slider)
        {
            if (ModelState.IsValid)
            {
                // Edit Trakt To DataBase
                Trakt trakt = _traktBusiness.GetTraktById(id);
                trakt.TraktCategoryId = traktViewModels.TraktCategoryId;
                trakt.Description = traktViewModels.Description;
                trakt.HaveSlider = traktViewModels.HaveSlider;
                trakt.Text = traktViewModels.Text;
                trakt.TraktTitle = traktViewModels.TraktTitle;
                trakt.TraktStatusId = traktViewModels.TraktStatusId;
                trakt.TraktTypeId = traktViewModels.TraktTypeId;
                trakt.FromDate = traktViewModels.FromDate;

                // Save Index Image To Storage
                string imageName = null;
                if (image != null && image.IsImage())
                {
                    if (trakt.ImageUrl != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Trakt/" + trakt.ImageUrl));
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Trakt/Thumbnail/" + trakt.ImageUrl));
                    }

                    imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("/Content/Image/Trakt/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Trakt/" + imageName),
                        Server.MapPath("/Content/Image/Trakt/Thumbnail/" + imageName));
                    trakt.ImageUrl = imageName;
                }

                // Save Slider Image To Storage
                string sliderName = null;
                if (slider != null && slider.IsImage())
                {
                    if (trakt.SliderImageUrl != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Trakt/" + trakt.SliderImageUrl));
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Trakt/Thumbnail/" + trakt.SliderImageUrl));
                    }

                    sliderName = Guid.NewGuid().ToString() + Path.GetExtension(slider.FileName);
                    slider.SaveAs(Server.MapPath("/Content/Image/Trakt/" + sliderName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Trakt/" + sliderName),
                        Server.MapPath("/Content/Image/Trakt/Thumbnail/" + sliderName));
                    trakt.SliderImageUrl = sliderName;
                }

                _traktBusiness.EditTrakt(trakt);
                _traktBusiness.Save();

                // Delete Old Trakt-Tags From DataBase
                _traktBusiness.DeleteTraktTagByTrakt(trakt);

                // Add Trakt-Tag To DataBase
                _traktBusiness.AddTraktTags(trakt.TraktId, tags);

                return RedirectToAction("ListTrakt");
            }

            ViewBag.Categories = _traktBusiness.GetAllTraktCategories();
            ViewBag.Types = _traktBusiness.GetAllTraktTypes();
            ViewBag.Status = _traktBusiness.GetAllTraktStatus();

            ViewBag.Tags = tags;
            ViewBag.Error = true;
            return PartialView(traktViewModels);
        }

        public void LockTrakt(long id)
        {
            _traktBusiness.LockTrakt(id);
        }

        public void DeleteTrakt(long id)
        {
            _traktBusiness.DeleteTrakt(id);
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult ListCategory()
        {
            IEnumerable<TraktCategory> categories = _traktBusiness.GetAllTraktCategories();
            return PartialView(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            ViewBag.Categories = _traktBusiness.GetAllRootTraktCategories();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(TraktCategory category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == 0)
                {
                    category.ParentId = null;
                }
                category.CreateDate = DateTime.Now;
                category.IsDeleted = false;
                _traktBusiness.AddTraktCategory(category);
                _traktBusiness.Save();

                return RedirectToAction("ListCategory");
            }

            ViewBag.Categories = _traktBusiness.GetAllRootTraktCategories();
            ViewBag.Error = true;
            return PartialView(category);
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            TraktCategory category = _traktBusiness.GetTraktCategoryById(id);
            ViewBag.Categories = _traktBusiness.GetAllRootTraktCategories();
            return PartialView(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(TraktCategory category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == 0 || category.ParentId == null)
                {
                    category.ParentId = null;
                }
                _traktBusiness.EditTraktCategory(category);
                _traktBusiness.Save();

                return RedirectToAction("ListCategory");
            }

            ViewBag.Categories = _traktBusiness.GetAllRootTraktCategories();
            ViewBag.Error = true;
            return PartialView(category);
        }

        public void DeleteCategory(int id)
        {
            _traktBusiness.DeleteTraktCategory(id);
        }
    }
}