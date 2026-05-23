using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models.Students;
using PersonalAccount.Services.Auth;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

[Authorize]
public class CabinetController(IStudentAuthService students) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var rawId = User.GetId();
        if (rawId == null) return RedirectToAction("Error", "Home");

        int studentId = Convert.ToInt32(rawId.Value);

        var student = await students.GetByIdAsync(studentId);

        if (student == null)
        {
            return RedirectToAction("Error", "Home");
        }
        return View(student);
    }
}