
namespace Entities
{
    public interface IUser
    {
        int User_Id { get; set; }
        string First_Name { get; set; }
        string Last_Name { get; set; }
        int Employee_Id { get; set; }
        int? Project_Id { get; set; }
        int? Task_Id { get; set; }
        Project Project { get; set; }
        Task Task { get; set; }
    }
}
