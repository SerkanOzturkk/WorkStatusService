using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<List<Employee>> GetAllByTeamId(int id);
        IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails();
        IDataResult<Employee> GetById(int employeeId);
        IResult Add(Employee employee);
        IResult Update(Employee employee);
        IResult Delete(Employee employee);
    }
}
