using Store.API.Domains.SharedModels;
using Store.API.Domains.UserModels;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Application.Interaces
{
    public interface IUserService
    {
        IEnumerable<T> GetAll<T>() where T : UserModel;
        IEnumerable<T> GetByCriteria<T, C>(C criteria) where T : UserModel where C : ICriteriaBaseModel<Person>;
        T GetById<T>(int id) where T : UserModel;
        T Add<T>(T entity) where T : UserModel;
        T Update<T>(T entity) where T : UserModel;
        int Delete(int id);
    }
}
