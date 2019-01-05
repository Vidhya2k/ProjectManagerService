using System.Linq;
using DataAccessLayer;
using Entities;
using Moq;
using NUnit.Framework;

namespace BusinessLogicLayer.Test
{
    [TestFixture]
    public class WhenUserManagerIsUsed
    {
        private IUserManager _userManager;
        private Mock<IUserDataAccess> _mockUserDataAccess;

        [SetUp]
        public void Setup()
        {
            _mockUserDataAccess = new Mock<IUserDataAccess>();
            _userManager = new UserManager(_mockUserDataAccess.Object);
        }

        [Test]
        public void ThatGetAllUsersIsInvoked()
        {
            // Arrange
            var mockUser1 = new Mock<IUser>();
            var mockUser2 = new Mock<IUser>();
            var users = new[] {mockUser1.Object, mockUser2.Object};
            _mockUserDataAccess.Setup(x => x.GetAllUsers()).Returns(users.AsQueryable());

            // Act
            var result = _userManager.GetAllUsers();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(users.Length));
        }

        [Test]
        public void ThatGetUserByIdIsInvokedForGivenId()
        {
            var mockUser = new Mock<IUser>();
            _mockUserDataAccess.Setup(x => x.GetUserById(1)).Returns(mockUser.Object);

            var result = _userManager.GetUserById(1);

            Assert.That(result, Is.EqualTo(mockUser.Object));
        }

        [Test]
        public void ThatAddUserInsertsNewRecord()
        {
            var mockUser = new Mock<IUser>();
            const int userId = 100;
            mockUser.SetupGet(x => x.User_Id).Returns(userId);
            _mockUserDataAccess.Setup(x => x.AddUser(mockUser.Object));

            _userManager.AddUser(mockUser.Object);

            _mockUserDataAccess.Verify(x => x.AddUser(mockUser.Object), Times.Once());
        }

        [Test]
        public void ThatDeleteUserDeletesOneRecord()
        {
            var mockUser = new Mock<IUser>();
            const int userId = 100;
            mockUser.SetupGet(x => x.User_Id).Returns(userId);
            _mockUserDataAccess.Setup(x => x.DeleteUser(mockUser.Object));

            _userManager.DeleteUser(mockUser.Object);

            _mockUserDataAccess.Verify(x => x.DeleteUser(mockUser.Object), Times.Once());
        }


        [Test]
        public void ThatUpdateUserUpdatesOneRecord()
        {
            var mockUser = new Mock<IUser>();
            const int userId = 100;
            mockUser.SetupGet(x => x.User_Id).Returns(userId);
            _mockUserDataAccess.Setup(x => x.UpdateUser(userId, mockUser.Object));

            _userManager.UpdateUser(userId, mockUser.Object);

            _mockUserDataAccess.Verify(x => x.UpdateUser(userId, mockUser.Object), Times.Once());
        }
    }
}
