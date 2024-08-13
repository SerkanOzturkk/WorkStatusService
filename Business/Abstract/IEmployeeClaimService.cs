using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IEmployeeClaimService
{
    IDataResult<List<EmployeeClaim>> GetAll();
    IDataResult<List<EmployeeClaim>> GetAllByClaimId(int claimId);
    IDataResult<List<EmployeeClaimDetailDto>> GetEmployeeClaimDetails();
    IDataResult<EmployeeClaim> GetById(int employeeClaimId);
    IResult Add(EmployeeClaim employeeClaim);
    IResult Update(EmployeeClaim employeeClaim);
    IResult Delete(EmployeeClaim employeeClaim);
}