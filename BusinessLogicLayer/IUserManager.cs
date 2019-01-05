using System.Linq;
using Entities;

namespace BusinessLogicLayer
{
    public interface IUserManager
    {
        IQueryable<IUser> GetAllUsers();
        IUser GetUserById(int id);
        void UpdateUser(int id, IUser User);
        void AddUser(IUser User);
        void DeleteUser(IUser User);
    }
}