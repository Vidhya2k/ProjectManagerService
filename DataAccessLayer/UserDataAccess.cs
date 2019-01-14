using System;
using System.Data.Entity;
using System.Linq;
using Entities;

namespace DataAccessLayer
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly ProjectManagementEntities _userContext = new ProjectManagementEntities();

        public IQueryable<IUser> GetAllUsers()
        {
           return _userContext.Users;
        }

        public IUser GetUserById(int id)
        {
            return _userContext.Users.Find(id);
        }

        public void UpdateUser(int id, IUser user)
        {
            _userContext.Entry(user).State = EntityState.Modified;
            _userContext.SaveChanges();
        }

        public void AddUser(IUser user)
        {
            _userContext.Users.Add((User)user);
            _userContext.SaveChanges();
        }

        public void DeleteUser(IUser user)
        {
            _userContext.Users.Remove((User)user);
            _userContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userContext != null)
                {
                    _userContext.Dispose();
                }
            }
        }
    }
}
