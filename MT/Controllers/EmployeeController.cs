using Microsoft.AspNetCore.Mvc;
using MT.Models;
using MT.Services.Interfaces;

namespace MT.Controllers;

[Route("[controller]/[action]")]
//[Route("[controller]")]
public class EmployeeController : Controller
{
    private readonly IManageEmployee _manageEmployee;
    public EmployeeController(IManageEmployee manageEmployee)
    {
        _manageEmployee = manageEmployee;
    }

    //[HttpGet]  
    [HttpGet("/[controller]")]
    public async Task<object> Index(CancellationToken token)
    {
        try
        {
            IEnumerable<EmployeeViewModel> employees = await _manageEmployee.GetEmployeeModelsAsync(token);
            return View(employees);
        }
        catch (Exception ex)
        {
            return View(new List<EmployeeViewModel>());
        }
    }
}
