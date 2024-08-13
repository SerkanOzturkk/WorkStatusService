using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class EmployeeClaimManager : IEmployeeClaimService
    {
        IEmployeeClaimDal _employeeClaimDal;

        public EmployeeClaimManager(IEmployeeClaimDal employeeClaimDal)
        {
            _employeeClaimDal = employeeClaimDal;
        }

        public IDataResult<List<EmployeeClaim>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeClaim>>(_employeeClaimDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<EmployeeClaim>> GetAllByClaimId(int claimId)
        {
            return new SuccessDataResult<List<EmployeeClaim>>(_employeeClaimDal.GetAll(e => e.ClaimId == claimId));
        }

        public IDataResult<List<EmployeeClaimDetailDto>> GetEmployeeClaimDetails()
        {
            return new SuccessDataResult<List<EmployeeClaimDetailDto>>(_employeeClaimDal.GetEmployeeClaimDetails());
        }

        public IDataResult<EmployeeClaim> GetById(int employeeClaimId)
        {
            return new SuccessDataResult<EmployeeClaim>(_employeeClaimDal.Get(e => e.Id == employeeClaimId));
        }

        public IResult Add(EmployeeClaim employeeClaim)
        {
            _employeeClaimDal.Add(employeeClaim);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(EmployeeClaim employeeClaim)
        {
            _employeeClaimDal.Update(employeeClaim);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(EmployeeClaim employeeClaim)
        {
            _employeeClaimDal.Delete(employeeClaim);

            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
