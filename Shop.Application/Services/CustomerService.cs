﻿using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using Shop.Application.Domains;
using Shop.Application.Infrastructures;
using Shop.Application.Interfaces;
using Shop.Persistance.Contexts;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Store.API.Application.Services
{
   public class CustomerService : ICustomerService
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;
        public CustomerService(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<T> GetAll<T>() where T : CustomerModel
        {
            var entities = _context.Customers
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : CustomerModel
            where C : ICriteriaBaseModel<Customer>
        {
            var entities = _context.Customers
                   .Where(criteria.Match())
                   .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                   .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public T GetById<T>(int id) where T : CustomerModel
        {
            throw new NotImplementedException();
        }

        public T Add<T>(T entity) where T : CustomerModel
        {
            var newPosition = _mapper.Map<Customer>(entity);
            newPosition.CreationDate = DateTime.Now;

            _context.Customers.Add(newPosition);
            _context.SaveChanges();

            return entity;
        }
        public T Update<T>(T entity) where T : CustomerModel
        {
            if (entity is null || entity.Id.Equals(0)) return null;
            var oldEntity = _context.Customers
                                             .FirstOrDefault(p => p.Id == entity.Id);
            if (oldEntity is null) return null;

            var updatedEntity = _mapper.Map<Customer>(entity);

            var changedFields = ObjectsComparer.GetChangedFields(oldEntity, updatedEntity);

            oldEntity.InjectFrom<AvoidNullProps>(updatedEntity);
            _context.Entry(oldEntity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerCriteria : ICriteriaBaseModel<Customer>
    {
        public int? Id { get ; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? ModificationDateFrom { get; set; }
        public DateTime? ModificationDateTo { get; set; }
        public string Name { get; set; }
       
        public Expression<Func<Customer, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Customer>(t => true);
            if (CreationDateFrom.HasValue) predicate = predicate.And(d => d.CreationDate >= CreationDateFrom);
            if (CreationDateTo.HasValue) predicate = predicate.And(d => d.CreationDate >= CreationDateTo);
            return predicate;
        }
    }
}
