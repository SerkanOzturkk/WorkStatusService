using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Entities.Abstract;

public interface IProjectDal : IEntityRepository<Project>
{
    List<ProjectDetailDto> GetProjectDetails();
}