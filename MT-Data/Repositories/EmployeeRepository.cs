namespace MT_Data.Repositories;

using Microsoft.EntityFrameworkCore;
using MT_Data.Context;
using MT_Data.Entities;
using MT_Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context)); ;
    }
    public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token)
    {
        IEnumerable <Employee> employees = await _context.employees.ToListAsync(token) ?? [];
        return employees;
    }
    public async Task<int> AddAsync(Employee employee,CancellationToken token)
    {
        await _context.employees.AddAsync(employee, token);
        var result = await _context.SaveChangesAsync(token);
        return result;
    }
}
