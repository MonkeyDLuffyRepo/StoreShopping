using Store.API.Domains.SharedModels;
using Store.API.Domains.VehiculeModels;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Application.Interaces
{
   public interface IVehiculeService
    {
        IEnumerable<T> GetAll<T>() where T : VehiculeModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : VehiculeModel where C : ICriteriaBaseModel<Vehicule>;
        T GetById<T>(int id) where T : VehiculeModel;
        T Add<T>(T entity) where T : VehiculeModel;
        T AddState<T>(T entity) where T : VehiculeStateModel;
        T Update<T>(T entity) where T : VehiculeModel;
        int Delete(int id);
    }
}
