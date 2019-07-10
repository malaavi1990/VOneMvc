using System;
using System.Collections.Generic;
using System.Linq;
using VOneBussines.Interfaces;
using VOneDal.UnitOfWork;
using VOneDomain.Models;
using VOneUtility.Enums;

namespace VOneBussines.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork _uow = new UnitOfWork();

        // Role Services
        public IEnumerable<Role> GetAllRoles()
        {
            try
            {
                return _uow.RoleDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // User Services
        public IEnumerable<User> GetAllUsers(IsDeletedEnum.IsDeleted isDeleted, int skip, int take)
        {
            try
            {
                if (take == 0 && skip == 0)
                {
                    if (isDeleted == IsDeletedEnum.IsDeleted.All)
                        return _uow.UserDal.Get();
                    else if (isDeleted == IsDeletedEnum.IsDeleted.OnlyUnDeleted)
                        return _uow.UserDal.Get(p => p.IsDeleted == false);
                    else
                        return _uow.UserDal.Get(p => p.IsDeleted == true);
                }
                else
                {
                    if (isDeleted == IsDeletedEnum.IsDeleted.All)
                        return _uow.UserDal.Get().Skip(skip).Take(take);
                    else if (isDeleted == IsDeletedEnum.IsDeleted.OnlyUnDeleted)
                        return _uow.UserDal.Get(p => p.IsDeleted == false).Skip(skip).Take(take);
                    else
                        return _uow.UserDal.Get(p => p.IsDeleted == true).Skip(skip).Take(take);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                return _uow.UserDal.GetById(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddUser(User user)
        {
            try
            {
                _uow.UserDal.Insert(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditUser(User user)
        {
            try
            {
                _uow.UserDal.Update(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                _uow.UserDal.Delete(userId);
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
    }
}
