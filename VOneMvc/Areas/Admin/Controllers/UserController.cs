using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VOneBussines.Interfaces;
using VOneDomain.Models;
using VOneMvc.Utilities;
using VOneUtility.Enums;
using VOneViewModels;

namespace VOneMvc.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListUser()
        {
            IEnumerable<User> users = _userBusiness.GetAllUsers(IsDeletedEnum.IsDeleted.OnlyUnDeleted, 0, 0);
            return PartialView(users);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            ViewBag.Roles = _userBusiness.GetAllRoles();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserViewModels userViewModel
        , HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string imageName = null;
                if (image != null && image.IsImage())
                {
                    imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("/Content/Image/User/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/User/" + imageName),
                        Server.MapPath("/Content/Image/User/Thumbnail/" + imageName));
                }

                User user = new User()
                {
                    ActiveCode = Guid.NewGuid().ToString(),
                    Address = userViewModel.Address,
                    Email = userViewModel.Email,
                    EmailConfirm = true,
                    FaildLoginCount = 0,
                    FullName = userViewModel.FullName,
                    IsLock = false,
                    MobileNumber = userViewModel.MobileNumber,
                    MobileConfirm = userViewModel.MobileNumber != null ? true : false,
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(userViewModel.Password, "MD5"),
                    RegisterDate = DateTime.Now,
                    UserName = userViewModel.UserName,
                    IsDeleted = false,
                    ProfileImage = imageName,
                    LastLogin = DateTime.Now
                };
                _userBusiness.AddUser(user);
                _userBusiness.Save();

                return RedirectToAction("ListUser");
            }

            ViewBag.Roles = _userBusiness.GetAllRoles();
            return PartialView(userViewModel);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            User user = _userBusiness.GetUserById(id);
            EditUserViewModels userViewModel = new EditUserViewModels()
            {
                MobileNumber = user.MobileNumber,
                FullName = user.FullName,
                Address = user.Address,
                Email = user.Email,
                UserName = user.UserName
            };

            ViewBag.Image = user.ProfileImage;
            ViewBag.Roles = _userBusiness.GetAllRoles();
            return PartialView(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(int id
            , EditUserViewModels userViewModel
            , HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                User user = _userBusiness.GetUserById(id);

                string imageName = null;
                if (image != null && image.IsImage())
                {
                    if (user.ProfileImage != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Product/" + user.ProfileImage));
                        System.IO.File.Delete(Server.MapPath("~/Content/Image/Product/Thumbnail/" + user.ProfileImage));
                    }

                    imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("/Content/Image/User/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/User/" + imageName),
                        Server.MapPath("/Content/Image/User/Thumbnail/" + imageName));

                    user.ProfileImage = imageName;
                }

                user.Address = userViewModel.Address;
                user.Email = userViewModel.Email;
                user.FullName = userViewModel.FullName;
                user.MobileNumber = userViewModel.MobileNumber;
                user.UserName = userViewModel.UserName;

                _userBusiness.EditUser(user);
                _userBusiness.Save();

                return RedirectToAction("ListUser");
            }

            ViewBag.Roles = _userBusiness.GetAllRoles();
            return PartialView(userViewModel);
        }

        public void LockUser(int id)
        {
            User user = _userBusiness.GetUserById(id);
            user.IsLock = user.IsLock != true;
            _userBusiness.EditUser(user);
            _userBusiness.Save();
        }

        public void DeleteUser(int id)
        {
            User user = _userBusiness.GetUserById(id);
            user.IsDeleted = true;
            _userBusiness.EditUser(user);
            _userBusiness.Save();
        }
    }
}