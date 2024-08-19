using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamService
    {
        IDataResult<List<Team>> GetAll();
        IDataResult<Team> GetById(int teamId);
        IResult Add(Team team);
        IResult Update(Team team);
        IResult Delete(Team team);
    }
}
