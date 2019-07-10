using System;
using VOneDal.Interfaces;
using VOneDal.Repositories;

namespace VOneDal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context = new DataContext();

        private IRoleDal _roleDal;
        public IRoleDal RoleDal =>
            _roleDal ?? (_roleDal = new RoleDal(_context));

        private IUserDal _userDal;
        public IUserDal UserDal =>
            _userDal ?? (_userDal = new UserDal(_context));

        private IProductDal _productDal;
        public IProductDal ProductDal =>
            _productDal ?? (_productDal = new ProductDal(_context));

        private IProductCategoryDal _productCategoryDal;
        public IProductCategoryDal ProductCategoryDal =>
            _productCategoryDal ?? (_productCategoryDal = new ProductCategoryDal(_context));

        private IProductGalleryDal _productGalleryDal;
        public IProductGalleryDal ProductGalleryDal =>
            _productGalleryDal ?? (_productGalleryDal = new ProductGalleryDal(_context));

        private IProductTagDal _productTagDal;
        public IProductTagDal ProductTagDal =>
            _productTagDal ?? (_productTagDal = new ProductTagDal(_context));

        private IProductStatusDal _productStatusDal;
        public IProductStatusDal ProductStatusDal =>
            _productStatusDal ?? (_productStatusDal = new ProductStatusDal(_context));

        private ISettingDal _settingDal;
        public ISettingDal SettingDal =>
            _settingDal ?? (_settingDal = new SettingDal(_context));

        private IPlantDal _plantDal;
        public IPlantDal PlantDal =>
            _plantDal ?? (_plantDal = new PlantDal(_context));

        private IPlantDetailsDal _plantDetailsDal;
        public IPlantDetailsDal PlantDetailsDal =>
            _plantDetailsDal ?? (_plantDetailsDal = new PlantDetailsDal(_context));

        private IPlantJoinTraktDal _plantJoinTraktDal;
        public IPlantJoinTraktDal PlantJoinTraktDal =>
            _plantJoinTraktDal ?? (_plantJoinTraktDal = new PlantJoinTraktDal(_context));

        private IPlantStatusDal _plantStatusDal;
        public IPlantStatusDal PlantStatusDal =>
            _plantStatusDal ?? (_plantStatusDal = new PlantStatusDal(_context));

        private IPlantTypeDal _plantTypeDal;
        public IPlantTypeDal PlantTypeDal =>
            _plantTypeDal ?? (_plantTypeDal = new PlantTypeDal(_context));

        private ITraktCategoryDal _traktCategoryDal;
        public ITraktCategoryDal TraktCategoryDal =>
            _traktCategoryDal ?? (_traktCategoryDal = new TraktCategoryDal(_context));

        private ITraktDal _traktDal;
        public ITraktDal TraktDal =>
            _traktDal ?? (_traktDal = new TraktDal(_context));

        private ITraktTagDal _traktTagDal;
        public ITraktTagDal TraktTagDal =>
            _traktTagDal ?? (_traktTagDal = new TraktTagDal(_context));

        private ITraktTypeDal _traktTypeDal;
        public ITraktTypeDal TraktTypeDal =>
            _traktTypeDal ?? (_traktTypeDal = new TraktTypeDal(_context));

        private ITraktStatusDal _traktStatusDal;
        public ITraktStatusDal TraktStatusDal =>
            _traktStatusDal ?? (_traktStatusDal = new TraktStatusDal(_context));

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
