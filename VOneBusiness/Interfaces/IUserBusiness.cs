using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using VOneDomain.Models;
using VOneUtility.Enums;

namespace VOneBussines.Interfaces
{
    public interface IUserBusiness
    {
        // Role Services
        IEnumerable<Role> GetAllRoles();

        // User Services
        IEnumerable<User> GetAllUsers(IsDeletedEnum.IsDeleted isDeleted, int skip, int take);
        User GetUserById(int userId);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
        void Save();
    }
}
