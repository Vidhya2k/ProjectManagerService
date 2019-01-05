using System;
using System.Linq;
using Entities;

namespace DataAccessLayer
{
    public interface IProjectManagerDataAccess : IDisposable
    {
        IQueryable<IProject> GetAllProjects();
        IProject GetProjectById(int id);
        void UpdateProject(int id, IProject project);
        void AddProject(IProject project);
        void DeleteProject(IProject project);
    }
}