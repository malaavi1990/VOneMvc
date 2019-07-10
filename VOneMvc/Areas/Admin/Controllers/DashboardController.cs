using System.Collections.Generic;
using System.Web.Mvc;
using VOneBussines.Interfaces;
using VOneDomain.Models;
using VOneUtility.Enums;

namespace VOneMvc.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IUserBusiness _userBusiness;
        public DashboardController(IProductBusiness productBusiness
            , IUserBusiness userBusiness)
        {
            _productBusiness = productBusiness;
            _userBusiness = userBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowMenu()
        {
            return PartialView();
        }

        public ActionResult ListProduct()
        {
            IEnumerable<Product> products =
                _productBusiness.GetAllProducts(IsDeletedEnum.IsDeleted.OnlyUnDeleted, 0, 6);
            return PartialView(products);
        }

        public ActionResult ListUser()
        {
            IEnumerable<User> users = 
                _userBusiness.GetAllUsers(IsDeletedEnum.IsDeleted.OnlyUnDeleted, 0, 6);
            return PartialView(users);
        }
    }
}