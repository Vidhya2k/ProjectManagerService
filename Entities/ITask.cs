

namespace Entities
{
    public interface ITask
    {
        int Task_Id { get; set; }
        int? Parent_Id { get; set; }
        int? Project_Id { get; set; }
        string Task_Description { get; set; }
        System.DateTime Start_Date { get; set; }
        System.DateTime End_Date { get; set; }
        int Priority { get; set; }
        string Status { get; set; }
        Project Project { get; set; }
    }
}
