using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using TaskStatus = Entities.Concrete.TaskStatus;

namespace Business.Concrete
{
    public class TaskStatusManager : ITaskStatusService
    {
        ITaskStatusDal _taskStatusDal;
        public TaskStatusManager(ITaskStatusDal taskStatusDal)
        {
            _taskStatusDal = taskStatusDal;
        }
        public IDataResult<List<TaskStatus>> GetAll()
        {
            return new SuccessDataResult<List<TaskStatus>>(_taskStatusDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<TaskStatus> GetById(int taskStatusId)
        {
            return new SuccessDataResult<TaskStatus>(_taskStatusDal.Get(p => p.Id == taskStatusId));
        }
    }
}
