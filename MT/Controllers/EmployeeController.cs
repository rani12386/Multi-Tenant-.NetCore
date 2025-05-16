using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MT.Helpers;
using MT.Models;
using MT.Services.Interfaces;

namespace MT.Controllers;

[Route("[controller]/[action]")]
//[Route("[controller]")]
public class EmployeeController : BaseController
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
            return BadRequest(Messages.Failure);
        }
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeViewModel employee, CancellationToken token)
    {
        try
        {
            bool result = await _manageEmployee.Create(employee, token);
            if (!result)
            {
                return BadRequest(Messages.Failure);
            }
            string SuccessMessage = string.Format(Messages.success, employee.Name);

            await AddFlashMessageAsync(FlashMessageTypes.SuccessMessage, SuccessMessage);

            return RedirectToAction("Index");//to redirect to Index means show all employees along with newly added record.
            //return Ok(SuccessMessage);
        }
        catch (Exception ex)
        {
            return BadRequest(Messages.Failure);
        }
    }
}
