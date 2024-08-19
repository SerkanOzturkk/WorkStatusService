using Business.Abstract;
using Business.Security.Hashing;
using Business.Security.JWT;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IEmployeeService _employeeService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IEmployeeService employeeService, ITokenHelper tokenHelper)
        {
            _employeeService = employeeService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<Employee> Register(EmployeeForRegisterDto employeeForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var employee = new Employee
            {
                Email = employeeForRegisterDto.Email,
                EmployeeName = employeeForRegisterDto.FullName,
                TeamId = 1,
                CreatedDate = DateTime.Now,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _employeeService.Add(employee);
            return new SuccessDataResult<Employee>(employee, "Kayıt oldu");
        }

        public IDataResult<Employee> Login(EmployeeForLoginDto userForLoginDto)
        {
            var userToCheck = _employeeService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Employee>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Employee>("Parola hatası");
            }

            return new SuccessDataResult<Employee>(userToCheck, "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_employeeService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Employee employee)
        {
            var claims = _employeeService.GetClaims(employee);
            var accessToken = _tokenHelper.CreateToken(employee, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access Token oluşturuldu");
        }
    }
}
