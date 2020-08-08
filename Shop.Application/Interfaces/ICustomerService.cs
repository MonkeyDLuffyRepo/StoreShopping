using Shop.Application.Domains;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interaces
{
    public interface ICustomerService
    {
        IEnumerable<T> GetAll<T>() where T : CustomerModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : CustomerModel where C : ICriteriaBaseModel<Customer>;
        T GetById<T>(int id) where T : CustomerModel;
        T Add<T>(T entity) where T : CustomerModel;
        T Update<T>(T entity) where T : CustomerModel;
        int Delete(int id);
    }
}
