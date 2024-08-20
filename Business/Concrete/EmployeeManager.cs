using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Employee>> GetAllByTeamId(int id)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.TeamId == id));
        }

        public IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails()
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeeDetails());
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.Id == employeeId));
        }

        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeToUpdate = GetById(updateEmployeeDto.Id);
            employeeToUpdate.Data.EmployeeName = updateEmployeeDto.EmployeeName;
            employeeToUpdate.Data.Email = updateEmployeeDto.Email;
            employeeToUpdate.Data.Status = updateEmployeeDto.Status;
            employeeToUpdate.Data.TeamId = updateEmployeeDto.TeamId;

            _employeeDal.Update(employeeToUpdate.Data);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(int teamId)
        {
            var result = GetById(teamId);

            if (!result.Success || result.Data == null)
            {
                return new ErrorResult(Messages.TeamNotFound);
            }

            _employeeDal.Delete(result.Data);

            return new SuccessResult(Messages.TeamNotFound);
        }

        public List<OperationClaim> GetClaims(Employee employee)
        {
            return _employeeDal.GetClaims(employee);
        }

        public Employee GetByMail(string email)
        {
            return _employeeDal.Get(u => u.Email == email);
        }
    }
}
