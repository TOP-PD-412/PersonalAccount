using PersonalAccount.Models.Students;

public interface IStudentService
{
    public Task<StudentModel?> GetStudentByIdAsync(int id);
    public Task<StudentModel?> GetStudentByEmailAsync(string email);
}