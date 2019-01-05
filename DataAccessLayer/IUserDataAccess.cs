using System;
using System.Linq;
using Entities;

namespace DataAccessLayer
{
    public interface IUserDataAccess : IDisposable
    {
        IQueryable<IUser> GetAllUsers();
        IUser GetUserById(int id);
        void UpdateUser(int id, IUser user);
        void AddUser(IUser user);
        void DeleteUser(IUser user);
    }
}