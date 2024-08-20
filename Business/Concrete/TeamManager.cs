using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }
        public IDataResult<List<Team>> GetAll()
        {
            return new SuccessDataResult<List<Team>>(_teamDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Team> GetById(int teamId)
        {
            return new SuccessDataResult<Team>(_teamDal.Get(e => e.Id == teamId));
        }

        public IResult Add(AddTeamDto addTeamDto)
        {
            Team team = new Team();
            team.TeamName = addTeamDto.TeamName;
            team.CreatedDate = DateTime.Now;

            _teamDal.Add(team);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(UpdateTeamDto updateTeamDto)
        {
            var teamToUpdate = GetById(updateTeamDto.Id);
            teamToUpdate.Data.TeamName = updateTeamDto.TeamName;

            _teamDal.Update(teamToUpdate.Data);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(int teamId)
        {
            // GetById metodunu kullanarak ID'ye göre takımı alıyoruz
            var teamToDelete = GetById(teamId);

            // Eğer takım bulunamazsa, hata döndürüyoruz
            if (!teamToDelete.Success || teamToDelete.Data == null)
            {
                return new ErrorResult(Messages.TeamNotFound);
            }

            // Takımı silme işlemi
            _teamDal.Delete(teamToDelete.Data);

            return new SuccessResult(Messages.TeamNotFound);
        }


    }
}
