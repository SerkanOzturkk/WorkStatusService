using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {

        IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Project>> GetAllByTeamId(int teamId)
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(p => p.TeamId == teamId));
        }

        public IDataResult<List<ProjectDetailDto>> GetProjectDetails()
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectDal.GetProjectDetails());
        }

        public IDataResult<Project> GetById(int projectId)
        {
            return new SuccessDataResult<Project>(_projectDal.Get(p => p.Id == projectId));
        }

        public IResult Add(AddProjectDto addProjectDto)
        {
            Project project = new Project();
            project.ProjectName = addProjectDto.ProjectName;
            project.TeamId = addProjectDto.TeamId;
            project.CreatedDate = DateTime.Now;

            _projectDal.Add(project);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(UpdateProjectDto updateProjectDto)
        {
            var projectToUpdate = GetById(updateProjectDto.Id);
            projectToUpdate.Data.ProjectName = updateProjectDto.ProjectName;
            projectToUpdate.Data.TeamId = updateProjectDto.TeamId;

            _projectDal.Update(projectToUpdate.Data);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(int projectId)
        {
            var projectToDelete = GetById(projectId);

            if (!projectToDelete.Success || projectToDelete.Data == null)
            {
                return new ErrorResult(Messages.TeamNotFound);
            }

            _projectDal.Delete(projectToDelete.Data);

            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
