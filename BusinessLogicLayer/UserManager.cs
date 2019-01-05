using System.Linq;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
    public class UserManager : IUserManager
    {
        private readonly IUserDataAccess _userDataAccess = new UserDataAccess();

        public UserManager()
        {
            
        }

        public UserManager(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public void AddUser(IUser user)
        {
            _userDataAccess.AddUser(user);
        }

        public void DeleteUser(IUser user)
        {
            _userDataAccess.DeleteUser(user);
        }

        public IQueryable<IUser> GetAllUsers()
        {
            return _userDataAccess.GetAllUsers();
        }

        public IUser GetUserById(int id)
        {
            return _userDataAccess.GetUserById(id);
        }

        public void UpdateUser(int id, IUser user)
        {
            _userDataAccess.UpdateUser(id, user);
        }
    }
}
