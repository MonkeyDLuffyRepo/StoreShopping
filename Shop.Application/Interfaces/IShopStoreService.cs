using Shop.Application.Domains;
using Shop.Persistance.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IShopStoreService
    {
        IEnumerable<T> GetAll<T>() where T : ShopStoreModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : ShopStoreModel where C : ICriteriaBaseModel<ShopStore>;
        T GetById<T>(int id) where T : ShopStoreModel;
        T Add<T>(T entity) where T : ShopStoreModel;
        T Update<T>(T entity) where T : ShopStoreModel;
        int Delete(int id);
    }
}
