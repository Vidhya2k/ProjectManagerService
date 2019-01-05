
using System.Collections.Generic;

namespace Entities
{
    public interface IProject
    {
        int Project_Id { get; set; }
        string Project_Description { get; set; }
        System.DateTime Start_Date { get; set; }
        System.DateTime End_Date { get; set; }
        int Priority { get; set; }
        ICollection<Task> Tasks { get; set; }
        ICollection<User> Users { get; set; }
    }
}
