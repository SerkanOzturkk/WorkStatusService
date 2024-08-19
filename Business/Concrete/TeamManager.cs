using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;

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

        public IResult Add(Team team)
        {
            _teamDal.Add(team);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Team team)
        {
            _teamDal.Update(team);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Team team)
        {
            _teamDal.Delete(team);

            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
