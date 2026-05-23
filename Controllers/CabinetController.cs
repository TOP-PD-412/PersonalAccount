using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models.Students;
using PersonalAccount.Services;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

[Authorize]
public class CabinetController(IStudentService students) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var studentId = User.GetId();
        if (studentId == null) return RedirectToAction("Error", "Home");
        
        var student = await students.GetStudentByIdAsync(studentId.Value);
        if (student == null) return RedirectToAction("Error", "Home");
        
        return View(student);
    }
}