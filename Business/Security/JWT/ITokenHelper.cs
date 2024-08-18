using Entities.Concrete;

namespace Business.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Employee employee, List<OperationClaim> claims);

    }
}
