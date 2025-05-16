using AutoMapper;
using MT.Models;
using MT.Services.Interfaces;
using MT_Data.Entities;
using MT_Data.Repositories.Interfaces;

namespace MT.Services
{
    public class ManageEmployeeService : IManageEmployee
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public ManageEmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeeModelsAsync(CancellationToken token)
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAllAsync(token);
            IEnumerable<EmployeeViewModel> employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return employeeViewModels;
        }

        public async Task<bool> Create(EmployeeViewModel employeeViewModel, CancellationToken token)
        {
            Employee employee =  _mapper.Map<Employee>(employeeViewModel);
            int value = await _employeeRepository.AddAsync(employee, token);
            return value > 0 ? true : false;
        }
    }
}
