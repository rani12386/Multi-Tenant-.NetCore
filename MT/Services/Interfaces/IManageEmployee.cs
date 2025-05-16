using MT.Models;
using MT_Data.Entities;

namespace MT.Services.Interfaces;
public interface IManageEmployee
{
    Task<IEnumerable<EmployeeViewModel>> GetEmployeeModelsAsync(CancellationToken token);
}
