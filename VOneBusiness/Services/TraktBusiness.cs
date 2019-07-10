using System;
using System.Collections.Generic;
using System.Linq;
using VOneBusiness.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;
using VOneUtility.Enums;

namespace VOneBusiness.Services
{
    public class TraktBusiness : ITraktBusiness
    {
        private readonly IUnitOfWork _uow = new UnitOfWork();

        // Trakt Services
        public IEnumerable<Trakt> GetAllTrakts(IsDeletedEnum.IsDeleted isDeleted, int skip, int take)
        {
            try
            {
                if (take == 0 && skip == 0)
                {
                    if (isDeleted == IsDeletedEnum.IsDeleted.All)
                        return _uow.TraktDal.Get();
                    else if (isDeleted == IsDeletedEnum.IsDeleted.OnlyUnDeleted)
                        return _uow.TraktDal.Get(p => p.IsDeleted == false);
                    else
                        return _uow.TraktDal.Get(p => p.IsDeleted == true);
                }
                else
                {
                    if (isDeleted == IsDeletedEnum.IsDeleted.All)
                        return _uow.TraktDal.Get().Skip(skip).Take(take);
                    else if (isDeleted == IsDeletedEnum.IsDeleted.OnlyUnDeleted)
                        return _uow.TraktDal.Get(p => p.IsDeleted == false).Skip(skip).Take(take);
                    else
                        return _uow.TraktDal.Get(p => p.IsDeleted == true).Skip(skip).Take(take);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Trakt GetTraktById(long id)
        {
            try
            {
                return _uow.TraktDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddTrakt(Trakt trakt)
        {
            try
            {
                _uow.TraktDal.Insert(trakt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditTrakt(Trakt trakt)
        {
            try
            {
                _uow.TraktDal.Update(trakt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTrakt(long id)
        {
            try
            {
                Trakt trakt = _uow.TraktDal.GetById(id);
                trakt.IsDeleted = true;
                _uow.TraktDal.Update(trakt);
                _uow.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

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

        // Trakt-Category Services
        public IEnumerable<TraktCategory> GetAllTraktCategories()
        {
            try
            {
                return _uow.TraktCategoryDal.Get(c => c.IsDeleted == false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<TraktCategory> GetAllRootTraktCategories()
        {
            try
            {
                return _uow.TraktCategoryDal.Get(c => c.ParentId == null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public TraktCategory GetTraktCategoryById(int id)
        {
            try
            {
                return _uow.TraktCategoryDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddTraktCategory(TraktCategory category)
        {
            try
            {
                _uow.TraktCategoryDal.Insert(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditTraktCategory(TraktCategory category)
        {
            try
            {
                _uow.TraktCategoryDal.Update(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTraktCategory(int id)
        {
            try
            {
                TraktCategory category = _uow.TraktCategoryDal.GetById(id);
                category.IsDeleted = true;
                _uow.TraktCategoryDal.Update(category);
                _uow.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Trakt-Status Services
        public IEnumerable<TraktStatus> GetAllTraktStatus()
        {
            try
            {
                return _uow.TraktStatusDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public TraktStatus GeTraktStatusById(int id)
        {
            try
            {
                return _uow.TraktStatusDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddTraktStatus(TraktStatus status)
        {
            try
            {
                _uow.TraktStatusDal.Insert(status);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditTraktStatus(TraktStatus status)
        {
            try
            {
                _uow.TraktStatusDal.Update(status);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTraktStatus(int id)
        {
            try
            {
                _uow.TraktStatusDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Trakt-Type Services
        public IEnumerable<TraktType> GetAllTraktTypes()
        {
            try
            {
                return _uow.TraktTypeDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public TraktType GeTraktTypeById(int id)
        {
            try
            {
                return _uow.TraktTypeDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddTraktType(TraktType type)
        {
            try
            {
                _uow.TraktTypeDal.Insert(type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditTraktType(TraktType type)
        {
            try
            {
                _uow.TraktTypeDal.Update(type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTraktType(int id)
        {
            try
            {
                _uow.TraktTypeDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Trakt-Tag Services
        public IEnumerable<TraktTag> GetTraktTagsByTraktId(long id)
        {
            try
            {
                return _uow.TraktTagDal.Get(t => t.TraktId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetStringTagsByTraktId(long id)
        {
            try
            {
                List<string> listTags = new List<string>();
                IEnumerable<TraktTag> traktTags = _uow.TraktTagDal.Get(t => t.TraktId == id);
                foreach (var tag in traktTags)
                {
                    listTags.Add(tag.TagTitle);
                }
                return String.Join(",", listTags);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddTraktTags(long id, string tags)
        {
            try
            {
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tagList = tags.Split(',').ToArray();
                    foreach (var tag in tagList)
                    {
                        TraktTag traktTag = new TraktTag()
                        {
                            CreateDate = DateTime.Now,
                            TagTitle = tag,
                            TraktId = id
                        };
                        _uow.TraktTagDal.Insert(traktTag);
                    }
                    _uow.Save();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void LockTrakt(long id)
        {
            try
            {
                Trakt trakt = _uow.TraktDal.GetById(id);
                trakt.IsActive = trakt.IsActive != true;
                _uow.TraktDal.Update(trakt);
                _uow.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTraktTag(long id)
        {
            try
            {
                _uow.TraktTagDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTraktTagByTrakt(Trakt trakt)
        {
            try
            {
                if (trakt.TraktTags.Any())
                {
                    foreach (var oldTag in trakt.TraktTags.ToList())
                    {
                        _uow.TraktTagDal.Delete(oldTag);
                    }
                    _uow.Save();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
