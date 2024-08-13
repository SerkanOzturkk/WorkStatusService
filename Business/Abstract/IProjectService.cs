using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProjectService 
{
    IDataResult<List<Project>> GetAll();
    IDataResult<List<Project>> GetAllByTeamId(int teamId);
    IDataResult<List<ProjectDetailDto>> GetProjectDetails();
    IDataResult<Project> GetById(int projectId);
    IResult Add(Project project);
    IResult Update(Project project);
    IResult Delete(Project project);
}