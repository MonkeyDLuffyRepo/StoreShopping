using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            if (_context.Customers.Any(p => p.UserName.Contains(entity.UserName)))
                return null;
            byte[] passwordHash, salt;

            var newUser = _mapper.Map<Customer>(entity);
            var DateNow = DateTime.Now;
            newUser.CreationDate = DateNow;
            newUser.ModificationDate = DateNow;
            UserHelpers.CreatePasswordHash(entity.Password, out passwordHash, out salt);
            newUser.Password = passwordHash;
            newUser.PasswordSalt = salt;

            _context.Customers.Add(newUser);
            _context.SaveChanges();

            return entity;
        }
        public T Authentification<T>(T entity) where T : UserModel
        {
            var user =  _context.Customers.
                FirstOrDefault(x => x.UserName.Equals(entity.UserName));
            if (user == null)
                return null;

            return !VerifyPasswordHash(entity.UserName, entity.Password, user.Password, user.PasswordSalt) ? null : _mapper.Map<T>(user);
        }

        /// <summary>
        /// VerifyPasswordHash
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string username, string password, byte[] passwordHash, byte[] salt)
        {
            var people = _context.Customers.FirstOrDefault(_ => _.UserName.Equals(username));
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != passwordHash[i]).Any())
                {
                    return false;
                }
            }

            if (people != null)
            {

                _context.Entry(people).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return true;
        }
    }
    public class UserHelpers
    {
        /// <summary>
        /// CreatePasswordHash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="salt"></param>
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            salt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
