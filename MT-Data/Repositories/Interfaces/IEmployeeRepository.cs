using MT_Data.Entities;

namespace MT_Data.Repositories.Interfaces;
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token);
    Task<int> AddAsync(Employee employee, CancellationToken token);
}
