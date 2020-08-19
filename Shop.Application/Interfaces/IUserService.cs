using Shop.Application.Domains;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Interfaces
{
   public interface IUserService
    {
        T GetById<T>(int id) where T : UserModel;
        T Add<T>(T entity) where T : UserModel;
        T Authentification<T>(T entity) where T : UserModel;
    }
}
