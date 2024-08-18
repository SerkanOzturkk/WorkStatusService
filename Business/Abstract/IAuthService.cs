using Business.Security.JWT;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Employee> Register(EmployeeForRegisterDto userForRegisterDto, string password);
        IDataResult<Employee> Login(EmployeeForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Employee employee);
    }
}
