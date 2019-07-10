using System;
using System.Collections.Generic;
using System.Text;
using VOneDal.Interfaces;

namespace VOneDal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleDal RoleDal { get; }
        IUserDal UserDal { get; }
        IProductDal ProductDal { get; }
        IProductCategoryDal ProductCategoryDal { get; }
        IProductGalleryDal ProductGalleryDal { get; }
        IProductTagDal ProductTagDal { get; }
        IProductStatusDal ProductStatusDal { get; }
        ISettingDal SettingDal { get; }
        IPlantDal PlantDal { get; }
        IPlantDetailsDal PlantDetailsDal { get; }
        IPlantJoinTraktDal PlantJoinTraktDal { get; }
        IPlantStatusDal PlantStatusDal { get; }
        IPlantTypeDal PlantTypeDal { get; }
        ITraktCategoryDal TraktCategoryDal { get; }
        ITraktDal TraktDal { get; }
        ITraktTagDal TraktTagDal { get; }
        ITraktTypeDal TraktTypeDal { get; }
        ITraktStatusDal TraktStatusDal { get; }

        void Save();
    }
}
