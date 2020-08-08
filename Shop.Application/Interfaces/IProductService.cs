
using Shop.Application.Domains;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
   public interface IProductService
    {
        IEnumerable<T> GetAll<T>() where T : ProductModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : ProductModel where C : ICriteriaBaseModel<Product>;
        T GetById<T>(int id) where T : ProductModel;
        T Add<T>(T entity) where T : ProductModel;
        T Update<T>(T entity) where T : ProductModel;
        int Delete(int id);
    }
}
