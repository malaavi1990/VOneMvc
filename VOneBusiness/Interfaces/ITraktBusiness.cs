using System.Collections.Generic;
using VOneDomain.Models;
using VOneUtility.Enums;

namespace VOneBusiness.Interfaces
{
    public interface ITraktBusiness
    {
        // Trakt Services
        IEnumerable<Trakt> GetAllTrakts(IsDeletedEnum.IsDeleted isDeleted, int skip, int take);
        Trakt GetTraktById(long id);
        void AddTrakt(Trakt trakt);
        void EditTrakt(Trakt trakt);
        void DeleteTrakt(long id);
        void Save();

        // Trakt-Category Services
        IEnumerable<TraktCategory> GetAllTraktCategories();
        IEnumerable<TraktCategory> GetAllRootTraktCategories();
        TraktCategory GetTraktCategoryById(int id);
        void AddTraktCategory(TraktCategory category);
        void EditTraktCategory(TraktCategory category);
        void DeleteTraktCategory(int id);

        // Trakt-Status Services
        IEnumerable<TraktStatus> GetAllTraktStatus();
        TraktStatus GeTraktStatusById(int id);
        void AddTraktStatus(TraktStatus status);
        void EditTraktStatus(TraktStatus status);
        void DeleteTraktStatus(int id);

        // Trakt-Type Services
        IEnumerable<TraktType> GetAllTraktTypes();
        TraktType GeTraktTypeById(int id);
        void AddTraktType(TraktType type);
        void EditTraktType(TraktType type);
        void DeleteTraktType(int id);

        // Trakt-Tag Services
        IEnumerable<TraktTag> GetTraktTagsByTraktId(long id);
        string GetStringTagsByTraktId(long id);
        void AddTraktTags(long id,string tags);
        void LockTrakt(long id);
        void DeleteTraktTag(long id);
        void DeleteTraktTagByTrakt(Trakt trakt);
    }
}
