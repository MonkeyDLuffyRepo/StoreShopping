using AutoMapper;
using Shop.Application.Domains;
using Shop.Application.Interfaces;
using Shop.Persistance.Contexts;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;
        public UserService(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public T Add<T>(T entity) where T : UserModel
        {
            var newPosition = _mapper.Map<Customer>(entity);
            newPosition.CreationDate = DateTime.Now;

            _context.Customers.Add(newPosition);
            _context.SaveChanges();

            return entity;
        }
        public T GetById<T>(int id) where T : UserModel
        {
            throw new NotImplementedException();
        }
        public T Authentification<T>(T entity) where T : UserModel
        {
            var user = _context.Customers.Where(c => c.UserName.ToLower() == entity.UserName.ToLower()).FirstOrDefault();
            return (T)(user != null && user.Password == entity.Password ? _mapper.Map<UserModel>(user) : null);
        }

       
    }
}
