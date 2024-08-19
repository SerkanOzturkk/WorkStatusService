using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfProjectDal : EfEntityRepositoryBase<Project, WorkStatusContext>, IProjectDal
{
    public List<ProjectDetailDto> GetProjectDetails()
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from p in context.Projects
                join t in context.Teams
                    on p.TeamId equals t.Id
                select new ProjectDetailDto
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    TeamName = t.TeamName
                };
            return result.ToList();
        }
    }
}