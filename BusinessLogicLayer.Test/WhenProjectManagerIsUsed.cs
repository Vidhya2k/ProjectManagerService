using System.Linq;
using DataAccessLayer;
using Entities;
using Moq;
using NUnit.Framework;

namespace BusinessLogicLayer.Test
{
    [TestFixture]
    public class WhenProjectManagerIsUsed
    {
        private IProjectManager _projectManager;
        private Mock<IProjectManagerDataAccess> _mockProjectDataAccess;

        [SetUp]
        public void Setup()
        {
            _mockProjectDataAccess = new Mock<IProjectManagerDataAccess>();
            _projectManager = new ProjectManager(_mockProjectDataAccess.Object);
        }

        [Test]
        public void ThatGetAllProjectsIsInvoked()
        {
            // Arrange
            var mockProject1 = new Mock<Project>();
            var mockProject2 = new Mock<Project>();
            var projects = new[] {mockProject1.Object, mockProject2.Object};
            _mockProjectDataAccess.Setup(x => x.GetAllProjects()).Returns(projects.AsQueryable());

            // Act
            var result = _projectManager.GetAllProjects();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(projects.Length));
        }

        [Test]
        public void ThatGetProjectByIdIsInvokedForGivenId()
        {
            var mockProject1 = new Mock<IProject>();
            _mockProjectDataAccess.Setup(x => x.GetProjectById(1)).Returns(mockProject1.Object);

            var result = _projectManager.GetProjectById(1);

            Assert.That(result, Is.EqualTo(mockProject1.Object));
        }

        [Test]
        public void ThatAddProjectInsertsNewRecord()
        {
            var mockProject = new Mock<IProject>();
            const int projectId = 100;
            mockProject.SetupGet(x => x.Project_Id).Returns(projectId);
            _mockProjectDataAccess.Setup(x => x.AddProject(mockProject.Object));

            _projectManager.AddProject(mockProject.Object);

            _mockProjectDataAccess.Verify(x => x.AddProject(mockProject.Object), Times.Once());
        }

        [Test]
        public void ThatDeleteProjectDeletesOneRecord()
        {
            var mockProject = new Mock<IProject>();
            const int projectId = 100;
            mockProject.SetupGet(x => x.Project_Id).Returns(projectId);
            _mockProjectDataAccess.Setup(x => x.DeleteProject(mockProject.Object));

            _projectManager.DeleteProject(mockProject.Object);

            _mockProjectDataAccess.Verify(x => x.DeleteProject(mockProject.Object), Times.Once());
        }


        [Test]
        public void ThatUpdateProjectUpdatesOneRecord()
        {
            var mockProject = new Mock<IProject>();
            const int projectId = 100;
            mockProject.SetupGet(x => x.Project_Id).Returns(projectId);
            _mockProjectDataAccess.Setup(x => x.UpdateProject(projectId, mockProject.Object));

            _projectManager.UpdateProject(projectId, mockProject.Object);

            _mockProjectDataAccess.Verify(x => x.UpdateProject(projectId, mockProject.Object), Times.Once());
        }
    }
}
