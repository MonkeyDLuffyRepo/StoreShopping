using Shop.Application.Domains;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interaces
{
   public interface IPanierService
    {
        IEnumerable<T> GetAll<T>() where T : PanierModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : PanierModel where C : ICriteriaBaseModel<Panier>;
        T GetById<T>(int id) where T : PanierModel;
        T Add<T>(T entity) where T : PanierModel;
        T AddState<T>(T entity) where T : PanierModel;
        T Update<T>(T entity) where T : PanierModel;
        int Delete(int id);
    }
}
