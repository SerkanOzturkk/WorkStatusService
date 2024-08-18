using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);

            return new SuccessResult(Messages.ProductDeleted);
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
