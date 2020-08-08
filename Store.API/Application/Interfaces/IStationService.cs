using Store.API.Domains.SharedModels;
using Store.API.Domains.StationModels;
using Store.Persistance.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Application.Interaces
{
    public interface IStationService
    {
        IEnumerable<T> GetAll<T>() where T : StationModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : StationModel where C : ICriteriaBaseModel<Station>;
        T GetById<T>(int id) where T : StationModel;
        T Add<T>(T entity) where T : StationModel;
        T Update<T>(T entity) where T : StationModel;
        int Delete(int id);
    }
}
