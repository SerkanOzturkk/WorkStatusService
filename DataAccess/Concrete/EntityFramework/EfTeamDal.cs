using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfTeamDal : EfEntityRepositoryBase<Team, WorkStatusContext>, ITeamDal
{
    public List<TeamDetailDto> GetTeamDetails()
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from t in context.Teams
                join e in context.Employees
                    on t.TeamLeaderId equals e.Id
                select new TeamDetailDto
                {
                    Id = t.Id,
                    TeamName = t.TeamName,
                    TeamLeaderName = e.EmployeeName
                };
            return result.ToList();
        }
    }
}