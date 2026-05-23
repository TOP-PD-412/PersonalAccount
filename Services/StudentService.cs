using PersonalAccount.Models.Students;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepo<StudentModel> _studentRepo;

    public StudentService(IStudentRepo<StudentModel> studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<StudentModel?> GetStudentByIdAsync(int id)
    {
        return await _studentRepo.GetByIdAsync(id);
    }

    public async Task<StudentModel?> GetStudentByEmailAsync(string email)
    {
        return await _studentRepo.GetByEmailAsync(email);
    }
}