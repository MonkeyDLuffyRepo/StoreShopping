
using Store.API.Domains.PositionModels;
using Store.API.Domains.SharedModels;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Application.Interaces
{
   public interface IPositionService
    {
        IEnumerable<T> GetAll<T>() where T : PositionModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : PositionModel where C : ICriteriaBaseModel<Position>;
        T GetById<T>(int id) where T : PositionModel;
        T Add<T>(T entity) where T : PositionModel;
        T Update<T>(T entity) where T : PositionModel;
        int Delete(int id);
    }
}
